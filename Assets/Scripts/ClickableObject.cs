using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{

    protected SpriteRenderer spriteRenderer;
    GameObject outlineObject;
    float outlineScale = 1.2f;


    public virtual void OnClicked()
    {

    }

    protected void OnMouseOver()
    {
        if(outlineObject != null)
        {
            outlineObject.SetActive(true);
        }
    }

    protected void OnMouseExit()
    {
        if(outlineObject != null)
        {
            outlineObject.SetActive(false);
        }
    }

    protected void CreateButtonOutline()
    {
        // Create a new GameObject for the outline
        outlineObject = new GameObject();
        outlineObject.name = "Outline";

        outlineObject.transform.position = transform.position;
        outlineObject.transform.rotation = Quaternion.identity;
        outlineObject.transform.parent = transform;
        outlineObject.transform.localScale = new Vector3(outlineScale, outlineScale, outlineScale); // Scale a little bigger than the original sprite

        // Adjust the SpriteRenderer properties for the outline
        SpriteRenderer outlineRenderer = outlineObject.AddComponent<SpriteRenderer>();
        outlineRenderer.sprite = spriteRenderer.sprite;
        outlineRenderer.color = Color.black;
        outlineRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;

        outlineObject.SetActive(false);
    }

}
