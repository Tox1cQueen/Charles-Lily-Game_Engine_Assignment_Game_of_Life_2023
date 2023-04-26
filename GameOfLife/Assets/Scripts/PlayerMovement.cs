using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpforce = 20;
    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        var Vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        Vel.y = rb.velocity.y;
        rb.velocity = Vel;

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpforce);
    }
}
