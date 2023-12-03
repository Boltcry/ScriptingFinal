using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : ClickableObject
{

    public float cookDuration = 6f;
    float timer = 0f;

    Animator anim;
    bool isCooking = false;

    Food readyFood;
    FoodScriptable foodToMake;
    public ProgressBar progressBar;


    void Start()
    {
        readyFood = transform.Find("Food")?.GetComponent<Food>();

        anim = GetComponent<Animator>();


    }


    void Update()
    {
        if (isCooking)
        {
            timer += Time.deltaTime;
            float cookingProgress = Mathf.Clamp01(timer / cookDuration);
            if(progressBar != null)
            {
                progressBar.UpdateProgressBar(cookingProgress);
            }

            if (timer >= cookDuration)
            {
                FinishCooking();
            }
        }
    }

    public override void OnClicked()
    {
        Debug.Log("End of Station OnClicked");

    }

    public void StartCooking(FoodScriptable aFoodData)
    {
        isCooking = true;
        timer = 0f;
        anim.SetBool("isCooking", isCooking);
        foodToMake = aFoodData;
        Debug.Log("Cooking Started!");
        progressBar.gameObject.SetActive(true);
        progressBar.UpdateProgressBar(0f);

    }

    void FinishCooking()
    {
        isCooking = false;
        anim.SetBool("isCooking", isCooking);
        readyFood.SetFoodData(foodToMake);
        Debug.Log("Cooking Finished!");
        progressBar.gameObject.SetActive(false);
    }
}
