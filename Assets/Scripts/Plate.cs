using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public List<Food> foodsOnPlate = new List<Food>();



    public bool IsEmpty()
    {
        foreach(Food food in foodsOnPlate)
        {
            if(!food.foodData.isEmpty)
            {
                return false;
            }
        }

        return true;
    }

    public bool ContainsFoodType(FoodScriptable.Type aFoodType)
    {
        foreach(Food food in foodsOnPlate)
        {
            if(food.foodData.type == aFoodType && !food.foodData.isEmpty) //if the food types match and the food in the list is not empty
            {
                return true;
            }
        }

        return false;
    }


    public void TransferFoodsToPlate(Plate aPlate)
    {
        foreach (Food food in foodsOnPlate)
        {
            foreach (Food foodOther in aPlate.foodsOnPlate)
            {
                if (Food.FoodsAreCompatible(food, foodOther))
                {
                    Food.SwapFoodData(food, foodOther);
                }
            }
        }
    }



    public void AddToPlate(Food aFood)
    {
        foreach(Food food in foodsOnPlate)
        {
            if(Food.FoodsAreCompatible(food, aFood))
            {
                Food.SwapFoodData(food, aFood);
            }
        }
    }


}
