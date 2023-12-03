using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ClickableObject
{

    public FoodScriptable foodData;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteToFoodData();

        base.CreateButtonOutline();


    }


    void Update()
    {
        
    }

    public override void OnClicked()
    {
        //
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
