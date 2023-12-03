using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    Image progressBar;


    void Start()
    {
        progressBar = GetComponent<Image>();
        UpdateProgressBar(0f);
    }


    public void UpdateProgressBar(float aProgress)
    {
        if(progressBar != null)
        {
            progressBar.fillAmount = aProgress;
        }
    }



}
