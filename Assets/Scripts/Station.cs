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
        SetAnimatorTypeFloat();


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

    }

    public void StartCooking(FoodScriptable aFoodData)
    {
        isCooking = true;
        timer = 0f;
        anim.SetBool("isCooking", isCooking);
        foodToMake = aFoodData;
        progressBar.gameObject.SetActive(true);
        progressBar.UpdateProgressBar(0f);

    }

    void FinishCooking()
    {
        isCooking = false;
        anim.SetBool("isCooking", isCooking);
        readyFood.SetFoodData(foodToMake);
        progressBar.gameObject.SetActive(false);
    }

    void SetAnimatorTypeFloat()
    {
        float stationType = 0f;
        switch (readyFood.foodData.type)
        {
            case FoodScriptable.Type.Meat:
                stationType = 0f;
                break;

            case FoodScriptable.Type.Vegetable:
                stationType = 0.3f;
                break;

            case FoodScriptable.Type.Carb:
                stationType = 0.7f;
                break;

            case FoodScriptable.Type.Drink:
                stationType = 1f;
                break;
        }

        anim.SetFloat("stationType", stationType);
    }
}
