using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public List<Food> foodsOnPlate = new List<Food>();
    public List<FoodScriptable> emptyFoodData = new List<FoodScriptable>();
    List<Food> originalFoodsOnPlate;


    void Start()
    {
        originalFoodsOnPlate = foodsOnPlate;
    }

    public void ResetPlate()
    {
        int index = 0;
        foreach(Food food in foodsOnPlate)
        {
            Debug.Log(foodsOnPlate.Count+"  foodsOnPlateCount");
            Debug.Log(emptyFoodData.Count+"  emptyFoodDataCount");
            food.SetFoodData(emptyFoodData[index]);
            index++;
        }
        Debug.Log("Plate Reset");
    }

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

    public bool HasSameFoods(Plate otherPlate)
    {
        // Create sets of food data for efficient comparison
        HashSet<FoodScriptable> thisPlateFoodData = new HashSet<FoodScriptable>();
        HashSet<FoodScriptable> otherPlateFoodData = new HashSet<FoodScriptable>();

        // Populate sets with food types from the current plate
        foreach (Food food in foodsOnPlate)
        {
            thisPlateFoodData.Add(food.foodData);
        }

        // Populate sets with food types from the other plate
        foreach (Food food in otherPlate.foodsOnPlate)
        {
            otherPlateFoodData.Add(food.foodData);
        }

        // Check if the sets are equal
        return thisPlateFoodData.SetEquals(otherPlateFoodData);
    }


}
