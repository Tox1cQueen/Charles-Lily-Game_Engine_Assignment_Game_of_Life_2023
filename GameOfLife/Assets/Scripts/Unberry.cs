using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unberry : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Berry")
        {
            other.tag = "Player";
        }
    }

    void OnTriggerStay(Collider other)
    {
    }
}