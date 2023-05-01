using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburStateManager : MonoBehaviour
{
    public Transform drilburTransform;
    public Transform player;
    public float speed;
    public Vector3 wanderTarget;
    public bool isWandering;
    public bool isFleeing;
    public Rigidbody rb;
    
    private DrilburBaseState _currentState;
    public DrilburFollowState _drilburFollowState = new DrilburFollowState();
    public DrilburRunState _drilburRunState = new DrilburRunState();
    public DrilburWanderState _drilburWanderState = new DrilburWanderState();
    

    // Start is called before the first frame update
    void Start()
    {
        _currentState = _drilburWanderState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        _currentState.UpdateState(this);
    }
    
    public void SwitchState(DrilburBaseState state)
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