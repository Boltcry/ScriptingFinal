using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : ClickableObject
{
    public CustomerScriptable customerData;
    private bool hasOrdered;
    private float menuLookDuration = 6f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteToCustomerData();

        base.CreateButtonOutline(); 
    }

    void Update()
    {
        
    }

    public override void OnClicked()
    {
        if (!hasOrdered)
        {
            StartCoroutine(LookAtMenuCoroutine());
        }
    }

    IEnumerator LookAtMenuCoroutine()
    {
        hasOrdered = true;

        yield return new WaitForSeconds(menuLookDuration);


        if (customerData != null && customerData.orders.Count > 0)
        {
            FoodScriptable customerOrder = customerData.orders[Random.Range(0, customerData.orders.Count)];

            Debug.Log("Customer ordered:" + customerOrder.foodName);
        }
    }

    public void SetCustomerData(CustomerScriptable aCustomerData)
    {
        customerData = aCustomerData;
        UpdateSpriteToCustomerData();
    }

    void UpdateSpriteToCustomerData()
    {
        if (customerData != null)
        {
            spriteRenderer.sprite = customerData.sprite;
        }
    }
}
