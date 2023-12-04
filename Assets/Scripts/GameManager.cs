using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public ClockHandMovement clockHand;
    public TextMeshProUGUI levelCompleteText;

    public DayScriptable currentDayData;
    public List<Customer> customerGameObjectsInScene = new List<Customer>();
    public Queue<CustomerScriptable> customersReadyToEnterScene = new Queue<CustomerScriptable>();
    public int index = 0;
    public int currentMoney = 0;

    float timeElapsed = 0f;


    private void Start()
    {
        if (currentDayData != null)
        {
            Debug.Log("Day Duration:" + currentDayData.dayDuration);
            Debug.Log("Money Goal:" + currentDayData.moneyGoal);
        }

        RotateHandOnClick(currentDayData.dayDuration);

    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(index < currentDayData.customerEntryTimes.Count)
        {
            if (timeElapsed >= currentDayData.customerEntryTimes[index])
            {
                customersReadyToEnterScene.Enqueue(currentDayData.customers[index]);
                index++;
            }
        }

        if(customersReadyToEnterScene.Count > 0)
        {
            Debug.Log("customers ready to enter scene are " + customersReadyToEnterScene.Count);
            Customer vacantSpot = GetVacantSpot(customerGameObjectsInScene);
            if (vacantSpot != null)
            {
                Debug.Log(" Vacant spot discovered!!");
                SpawnCustomer(vacantSpot);
            }
        }
    }

    Customer GetVacantSpot(List<Customer> aCustomers)
    {
        foreach(Customer aCustomer in aCustomers)
        {
            if(aCustomer.customerData.isVacant)
            {
                return aCustomer;
            }
            Debug.Log(aCustomer.customerData.isVacant + "");
        }
        return null;
    }

    private void RotateHandOnClick(float duration)
    {
        if (clockHand != null)
        {
            StartCoroutine(WhenTimerDone(duration));
        }
    }

    private IEnumerator WhenTimerDone(float duration)
    {
        yield return clockHand.RotateHandCoroutine(Quaternion.Euler(0f, 0f, 360f), duration);

        if (levelCompleteText != null)
        {
            levelCompleteText.text = "Level Complete!";
            levelCompleteText.gameObject.SetActive(true);
        }

        UpdateMoney();
    }


    void UpdateMoney()
    {
        currentMoney += currentDayData.moneyGoal;

        Debug.Log("Current Money:" + currentMoney);
    }
    


    void SpawnCustomer(Customer aCustomer)
    {
        Debug.Log("Spawning customer");
        CustomerScriptable customerData = customersReadyToEnterScene.Dequeue();
        aCustomer.customerData = customerData;
        aCustomer.customerData.isVacant = false;
    }
}
