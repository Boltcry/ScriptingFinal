using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomer", menuName = "ScriptableObjects/Customer")]
public class CustomerScriptable : ScriptableObject
{
    public Sprite sprite;
    public bool isVacant = true;

    public List<FoodScriptable> orders = new List<FoodScriptable>();

}
