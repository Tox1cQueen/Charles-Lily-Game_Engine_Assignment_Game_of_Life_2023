using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Among Us");
        if (other.tag == "Player")
        {
            other.tag = "Berry";
        }
        
        Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
    }
}
