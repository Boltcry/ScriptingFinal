using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public ClockHandMovement clockHand;

    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyGoalText;

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

        UpdateMoney(0);
        DisplayMoneyGoal();

        StartCoroutine(PlayLevel());
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
                //Debug.Log(" Vacant spot discovered!!");
                return aCustomer;
            }
        }
        return null;
    }

    private void RotateHandOnClick(float duration)
    {
        if (clockHand != null)
        {
            StartCoroutine(PlayLevel());
        }
    }

    private IEnumerator PlayLevel()
    {
        yield return clockHand.RotateHandCoroutine(Quaternion.Euler(0f, 0f, 360f), currentDayData.dayDuration);

        if (currentMoney >= currentDayData.moneyGoal)
        {
            if (levelCompleteText != null)
            {
                levelCompleteText.text = "Level Complete!";
                levelCompleteText.gameObject.SetActive(true);
            }
        }
        else
        {
            if (levelCompleteText != null)
            {
                levelCompleteText.text = "Level Failed...";
                levelCompleteText.gameObject.SetActive(true);
            }
        }
    }


    public void UpdateMoney(int moneyEarned)
    {
        currentMoney += moneyEarned;

        moneyText.text = "Current Earnings: " + currentMoney.ToString();

        Debug.Log("Current Money:" + currentMoney);
    }

    private void DisplayMoneyGoal()
    {
        moneyGoalText.text = "Money Goal: " + currentDayData.moneyGoal.ToString();
    }



    void SpawnCustomer(Customer aCustomer)
    {
        //Debug.Log("Spawning customer");
        CustomerScriptable customerData = customersReadyToEnterScene.Dequeue();
        aCustomer.SetCustomerData(customerData);
    }
}
