using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public GameObject self;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Among Us");
        if (other.tag == "Player")
        {
            other.gameObject.tag = "Berry";
        }
    }

    void OnTriggerStay(Collider other)
    {
       Destroy(self);
    }
}
