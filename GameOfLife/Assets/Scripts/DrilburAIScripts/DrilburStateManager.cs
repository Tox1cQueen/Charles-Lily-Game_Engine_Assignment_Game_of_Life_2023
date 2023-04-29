using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburStateManager : MonoBehaviour
{

    public Transform player;
    public float speed;
    public Vector3 wanderTarget;
    public bool isWandering;
    
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
        _currentState.UpdateState(this);
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

}
