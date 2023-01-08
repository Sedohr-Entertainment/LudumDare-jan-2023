using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject _collectiblePrefab;
    [SerializeField] private bool _isFullyGrown = false;
    [SerializeField] private bool _canGrow = false;
    [SerializeField] private float _growthDuration = 10.0f;
    [SerializeField] private float _wilkRate = 10.0f;
    [SerializeField] private float _hydrationValue = 100.0f;

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
        _canGrow = true;
        return cropValue;
    }

    private void Start()
    {
        RandomCropType();
    }

    private void Update()
    {
        if (!_isFullyGrown && _canGrow)
        {
            // Increase the plant's size over time
            transform.localScale += Vector3.one * Time.deltaTime / _growthDuration;

            // Check if the plant is fully grown
            if (transform.localScale.x >= 1)
            {
                _isFullyGrown = true;
            }
        }
        else if (_isFullyGrown)
        {
            // Reduce the plant's hydration over time
            _hydrationValue -= Time.deltaTime * _wilkRate;

            // Check if the plant has wilked
            if (_hydrationValue <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Harvest the plant, spawning a new collectible game object
    public void Harvest()
    {
        // Instantiate a new collectible game object
        GameObject collectible = Instantiate(_collectiblePrefab, transform.position, transform.rotation);

        // Set the collectible's type based on the plant's type
        //collectible.GetComponent<CollectibleController>().type = type;

        // Destroy the plant game object
        Destroy(gameObject);
    }
}
