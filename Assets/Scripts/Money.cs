using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : ClickableObject
{

    public GameManager gameManager;


    void Start()
    {
        if(gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        base.CreateButtonOutline();
        
    }


    public override void OnClicked()
    {
        gameManager.UpdateMoney(30);
        gameObject.SetActive(false);
    }
}
