using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZubatStateManager : MonoBehaviour
{

    public Transform player;
    public float speed;
    public Vector3 wanderTarget;
    public bool isWandering;
    public bool isFleeing;
    public Rigidbody rb;
    
    private ZubatBaseState _currentState;
    public ZubatFollowState _zubatFollowState = new ZubatFollowState();
    public ZubatRunState _zubatRunState = new ZubatRunState();
    public ZubatWanderState _zubatWanderState = new ZubatWanderState();
    

    // Start is called before the first frame update
    void Start()
    {
        _currentState = _zubatWanderState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        _currentState.UpdateState(this);
    }
    
    public void SwitchState(ZubatBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentState.OnTrig(this, other);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        _currentState.OnTrigExit(this);
    }

    public void OnTriggerStay(Collider other)
    {
        _currentState.OnTrigStay(this, other);
    }
}
