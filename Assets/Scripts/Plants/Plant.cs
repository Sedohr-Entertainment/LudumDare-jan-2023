using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private CropType _cropType;
    public enum CropType
    {
        CARROT, 
        TOMATO,
        WHEAT
    }

    //Return random crop value from enum values.
    private CropType RandomCropType()
    {
        Type randomCrop = typeof(CropType);
        Array values = randomCrop.GetEnumValues();
        int index = UnityEngine.Random.Range(0, values.Length);
        CropType cropValue = (CropType)values.GetValue(index);
        Debug.Log("Current crop" + cropValue);
        return cropValue;
    }

    private void Start()
    {
        RandomCropType();
    }
}
