using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringHole : MonoBehaviour
{
    private float _waterValue = 1f;
    private bool _canCollect = true;
    public static event Action<float> onWaterGathered;

    void GiveWater() {
        //TODO pass watervalue to the player inventory? 
        //GameObject.FindGameObjectWithTag("Player");
        if (_canCollect)
        {
            onWaterGathered?.Invoke(_waterValue);
        }
    }


}
