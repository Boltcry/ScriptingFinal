using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : ClickableObject
{

    public float cookDuration = 6f;
    float timer = 0f;

    Animator anim;
    bool isCooking = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (isCooking)
        {
            timer += Time.deltaTime;

            if (timer >= cookDuration)
            {
                isCooking = false;
            }
        }
    }

    public override void OnClicked()
    {
        Debug.Log("End of Station OnClicked");

    }

    public void StartCooking()
    {
        isCooking = true;
        
    }
}
