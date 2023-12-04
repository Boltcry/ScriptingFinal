using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDay", menuName = "ScriptableObjects/Day")]
public class DayScriptable : ScriptableObject
{
    public float dayDuration = 100.0f;

    public List<CustomerScriptable> customers = new List<CustomerScriptable>();

    public List<float> customerEntryTimes = new List<float>();

    public int moneyGoal = 1000;
}
