using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrderOnStart : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = Mathf.FloorToInt(-transform.position.y * 10);
        }
    }

}
