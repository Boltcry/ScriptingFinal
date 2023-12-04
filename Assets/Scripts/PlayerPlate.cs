using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlate : Plate
{

    public static PlayerPlate Instance;


    void Awake()
    {
        Instance = this;
    }


}
