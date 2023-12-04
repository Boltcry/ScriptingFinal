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
    public List<GameObject> customerGameObjectsInScene = new List<GameObject>();
    public List<CustomerScriptable> customersReadyToEnterScene = new List<CustomerScriptable>();
    public int currentMoney = 0;


    private void Start()
    {
        if (currentDayData != null)
        {
            Debug.Log("Day Duration:" + currentDayData.dayDuration);
            Debug.Log("Money Goal:" + currentDayData.moneyGoal);
        }

        RotateHandOnClick(100f);

        StartCoroutine(SpawnCustomersOverTime());
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

        UpdateCustomerLists();
        UpdateMoney();
    }

    void UpdateCustomerLists()
    {
        customersReadyToEnterScene.AddRange(currentDayData.customers);

        foreach (CustomerScriptable customerData in customersReadyToEnterScene)
        {
            GameObject customerGameObject = InstantiateCustomerGameObject(customerData);
            customerGameObjectsInScene.Add(customerGameObject);
        }

        customersReadyToEnterScene.Clear();
    }

    void UpdateMoney()
    {
        currentMoney += currentDayData.moneyGoal;

        Debug.Log("Current Money:" + currentMoney);
    }
    
    GameObject InstantiateCustomerGameObject(CustomerScriptable customerData)
    {
        GameObject customerGameObject = new GameObject("Customer");
        
        return customerGameObject;
    }

    IEnumerator SpawnCustomersOverTime()
    {
        foreach (float entryTime in currentDayData.customerEntryTimes)
        {
            yield return new WaitForSeconds(entryTime);

            SpawnCustomer();
        }
    }

    void SpawnCustomer()
    {
        if (customersReadyToEnterScene.Count > 0)
        {
            CustomerScriptable customerData = customersReadyToEnterScene[0];
            GameObject customerGameObject = InstantiateCustomerGameObject(customerData);
            customerGameObjectsInScene.Add(customerGameObject);
            customersReadyToEnterScene.RemoveAt(0);
        }
    }
}
