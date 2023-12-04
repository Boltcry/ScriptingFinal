using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlate : Plate
{

    public static PlayerPlate Instance;
    PlayerController playerController;


    void Awake()
    {
        Instance = this;
        Instance.playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(!Instance.IsEmpty())
        {
            playerController.SetIsCarryingFood(true);
        }
        else
        {
            playerController.SetIsCarryingFood(false);
        }
    }


}
