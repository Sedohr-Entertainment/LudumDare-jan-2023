using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{

    public static event Action onSpacePressed;

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "GrowArea")
        {
            Debug.Log("Space was pressed");

            //Call on Growing Area
            //TODO needs a reference of some kind to the inventory of the player and the item currently held???
            onSpacePressed?.Invoke();

        }
    }

    //private void OnTriggerStay(Collider other)
    //{        
    //        if (Input.GetKeyDown(KeyCode.Space) && other.tag == "GrowArea")
    //        {
    //            Debug.Log("Space was pressed");

    //            //Call on Growing Area
    //            //TODO needs a reference of some kind to the inventory of the player and the item currently held???
    //            onSpacePressed?.Invoke();

    //        }
        
    //}

}
