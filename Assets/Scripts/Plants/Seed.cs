using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static event Action<CropType> onSeedGrown; 

    float decayTime = 10.0f;
    private CropType _cropType;
    public enum CropType { 
        GRAIN,
        WHEAT
    }

    //Return random crop value from enum values.
    CropType RandomCroptType() {
        Type randomCrop = typeof(CropType);
        Array values = randomCrop.GetEnumValues();
        int index = UnityEngine.Random.Range(0, values.Length);
        CropType cropValue = (CropType)values.GetValue(index);
        Debug.Log("Current crop" + cropValue);
        return cropValue;
    }

    private void Update()
    {
        Decay();
    }

    void Decay() { 
        decayTime -= Time.deltaTime;
        if (decayTime < 0) { RemoveSeed(); }
    }

    //When the seed has been planted, invoke event and pass in croptype and then destroy the seed gameobject.
    void PlantSeed() {        
        onSeedGrown?.Invoke(RandomCroptType());
        RemoveSeed();
    }

    private void RemoveSeed() {
        Destroy(gameObject);       
    }
}
