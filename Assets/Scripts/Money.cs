using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : ClickableObject
{



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.CreateButtonOutline();
        
    }


    public override void OnClicked()
    {
        
    }
}
