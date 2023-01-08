using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowArea : MonoBehaviour
{
   
    [SerializeField] private GameObject _plant, _collectiblePrefab;
    [SerializeField] private bool _isHolding = false, _isFullyGrown = false;
    public float growthDuration = 10.0f, wilkRate = 10.0f, hydrationValue = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (!_isFullyGrown)
        {
            // Increase the plant's size over time
            transform.localScale += Vector3.one * Time.deltaTime / growthDuration;

            // Check if the plant is fully grown
            if (transform.localScale.x >= 1)
            {
                _isFullyGrown = true;
            }
        }
        else if (_isFullyGrown)
        {
            // Reduce the plant's hydration over time
            hydrationValue -= Time.deltaTime * wilkRate;

            // Check if the plant has wilked
            if (hydrationValue <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

  

    public void SetPlant(GameObject currentPlant) 
    {             
        _plant = currentPlant;
        _isHolding = true;
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


    //used for resetting the area to null (removing crops)
    public void RemovePlant() {
        if (_plant != null)
        {

            _plant = null;
            _isHolding = false;
        }
    }


}
