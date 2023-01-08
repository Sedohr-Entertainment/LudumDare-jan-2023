using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowArea : MonoBehaviour
{

    [SerializeField] private GameObject _growingSeed;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private Seed _seed;
    [SerializeField] private bool _isHolding = false;

    private void Start()
    {
        SetPlant();    
    }

    public void SetPlant() 
    {             
        _seed = _growingSeed.GetComponent<Seed>();
        _isHolding = true;
        _seed.PlantSeed(_plantPrefab, gameObject.GetComponentInChildren<Transform>().gameObject);
    }

    //used for resetting the area to null (removing crops)
    public void RemovePlant() {
        if (_seed != null)
        {
            _seed = null;
            _isHolding = false;
        }
    }    
}
