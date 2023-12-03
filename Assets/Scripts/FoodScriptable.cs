using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewFood", menuName = "ScriptableObjects/Food")]
public class FoodScriptable : ScriptableObject
{
    public enum Type
    {
        Meat,
        Vegetable,
        Carb,
        Drink
    }

    public Sprite sprite;
    public Type type;
    public bool isEmpty = false;


}
