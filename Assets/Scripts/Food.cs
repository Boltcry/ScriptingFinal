using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ClickableObject
{

    public FoodScriptable foodData;
    public Plate plate;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteToFoodData();

        if(plate == null)
        {
            plate = transform.parent?.GetComponent<Plate>();
        }

        base.CreateButtonOutline();


    }


    public override void OnClicked()
    {
        //Debug.Log("Food clicked!");
        if(plate != null) //if the food has a plate
        {
            //Debug.Log("food has a plate");
            if (!PlayerPlate.Instance.IsEmpty()) // If player's plate is NOT empty
            {
                //Debug.Log("player's plate is NOT empty");
                PlayerPlate.Instance.TransferFoodsToPlate(plate);
            }
            else //if the player's plate IS empty
            {
                //Debug.Log("Player's plate IS empty");
                if(!plate.IsEmpty()) //If the plate is NOT empty
                {
                    //Debug.Log("plate is NOT empty");
                    plate.TransferFoodsToPlate(PlayerPlate.Instance);
                }
            }
        }

        else //if the food does NOT have a plate
        {
            PlayerPlate.Instance.AddToPlate(this);
        }
    }

    public static void SwapFoodData(Food aFood1, Food aFood2)
    {
        FoodScriptable tempFoodData = aFood1.foodData;
        aFood1.SetFoodData(aFood2.foodData);
        aFood2.SetFoodData(tempFoodData);
    }

    public static bool FoodsAreCompatible(Food aFood, Food aFoodOther)
    {
        return !(aFood.TypeMatches(aFoodOther) && !(aFood.foodData.isEmpty && aFoodOther.foodData.isEmpty));
    }

    public bool TypeMatches(Food aFood)
    {
        return foodData.type == aFood.foodData.type;
    }

    public void SetFoodData(FoodScriptable aFoodData)
    {
        foodData = aFoodData;
        UpdateSpriteToFoodData();

    }

    void UpdateSpriteToFoodData()
    {
        if (foodData != null)
        {
            spriteRenderer.sprite = foodData.sprite;
        }
    }

}
