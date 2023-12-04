using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBubble : ClickableObject
{

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.CreateButtonOutline();
    }

    public override void OnClicked()
    {
        transform.parent?.GetComponent<Customer>()?.OnClicked();
    }

}
