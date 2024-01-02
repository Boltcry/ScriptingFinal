using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : ClickableObject
{
    public Plate plate;
    public OrderBubble orderBubble;
    public CustomerScriptable customerData;
    public Money money;
    private bool hasOrdered;
    private float menuLookDuration = 6f;
    private CustomerScriptable originalCustomerData;
    
    void Start()
    {
        plate = transform.Find("Plate")?.GetComponent<Plate>();
        orderBubble = transform.Find("orderBubble")?.GetComponent<OrderBubble>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteToCustomerData();

        //base.CreateButtonOutline(); 

        originalCustomerData = customerData;
    }

    void Update()
    {
        
    }

    public override void OnClicked()
    {
        if (!hasOrdered)
        {
            //Debug.Log("Customer has started order");
            StartCoroutine(LookAtMenuCoroutine());
        }
        else
        {
            if(plate.HasSameFoods(PlayerPlate.Instance))
            {
                Leave();
            }
        }
    }

    IEnumerator LookAtMenuCoroutine()
    {

        yield return new WaitForSeconds(menuLookDuration);


        if (customerData != null && customerData.preferredOrder.Count > 0)
        {
            SetCustomerOrder(customerData.preferredOrder);
        }
        orderBubble.gameObject.SetActive(true);
        hasOrdered = true;
    }

    public void SetCustomerData(CustomerScriptable aCustomerData)
    {
        customerData = aCustomerData;
        UpdateSpriteToCustomerData();
    }

    public void SetCustomerOrder(List<FoodScriptable> aPreferredOrder)
    {
        int index = 0;
        foreach(Food aFood in plate.foodsOnPlate)
        {
            aFood.SetFoodData(aPreferredOrder[index]);
            index++;
        }
    }

    void UpdateSpriteToCustomerData()
    {
        if (customerData != null)
        {
            spriteRenderer.sprite = customerData.sprite;
        }
    }

    void Leave()
    {
        orderBubble.gameObject.SetActive(false);
        money.gameObject.SetActive(true);

        SetCustomerData(originalCustomerData);
        PlayerPlate.Instance.ResetPlate();
        plate.ResetPlate();
        hasOrdered = false;
        base.CreateButtonOutline(); 
    }
}
