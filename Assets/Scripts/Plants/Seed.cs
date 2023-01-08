using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    // Whether the plant has been planted
    private bool _isPlanted = false;
    private float _decayTime = 10.0f;

    private void Update()
    {
        Decay();
    }

    void Decay() { 
        _decayTime -= Time.deltaTime;
        if (!_isPlanted && _decayTime < 0) { RemoveSeed(); }
    }

    public void PlantSeed(GameObject plantPrefab, GameObject plantHolder) {                
        _isPlanted = true;
        GameObject plant = GameObject.Instantiate(plantPrefab, plantHolder.transform.position, Quaternion.identity);
        RemoveSeed();
    }

    private void RemoveSeed() {
        Destroy(gameObject);       
    }
}
