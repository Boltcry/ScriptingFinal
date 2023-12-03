using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationButton : ClickableObject
{

    public Food foodData;




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
        if(transform.parent != null)
        {
            transform.parent.StartCooking(foodData);
        }

        Debug.Log("End of StationButton OnClicked");

    }


}
