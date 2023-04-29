using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{

    public Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z);
    }
}
