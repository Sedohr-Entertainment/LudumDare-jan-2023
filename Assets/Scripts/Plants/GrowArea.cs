using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowArea : MonoBehaviour
{
   
    [SerializeField] private bool _isHolding = false;
    [SerializeField] private GameObject _plant;

    private void OnEnable(){ PlantController.onSpacePressed += SetPlant; }
    private void OnDisable(){ PlantController.onSpacePressed -= SetPlant;}

    public void SetPlant()
    {
        Debug.Log("Plant has been set");
        _isHolding = true;
    }

    //TODO Use this method to set the current plant of the growArea when referenced plant is retrieved from action.
    public void SetPlant(GameObject currentPlant) 
    {             
        _plant = currentPlant;
        _isHolding = true;
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
