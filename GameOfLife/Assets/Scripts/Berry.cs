using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.tag = "Berry";
        }
    }

    void OnTriggerStay(Collider other)
    {
    }
}
