using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationButton : ClickableObject
{

    public FoodScriptable foodData;




    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(foodData != null)
        {
            spriteRenderer.sprite = foodData.sprite;
        }

        base.CreateButtonOutline();

    }

 
    void Update()
    {
        
    }

    public override void OnClicked()
    {
        transform.parent?.GetComponent<Station>()?.StartCooking(foodData);


    }


}
