using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottlerStateManager : MonoBehaviour
{

    public Transform player;
    public float speed;
    public Vector3 wanderTarget;
    public bool isWandering;
    public bool isFleeing;
    public Rigidbody rb;
    public bool followingDrilbur = false;
    public Transform drilbur;
    public AudioSource source;
    public float minWait = 5f;
    public float maxWait = 10f;
    public float waitTimer = -2f;

    
    public DottlerBaseState _currentState;
    public DottlerFollowState _dottlerFollowState = new DottlerFollowState();
    public DottlerRunState _dottlerRunState = new DottlerRunState();
    public DottlerWanderState _dottlerWanderState = new DottlerWanderState();
    public DottlerFollowDrilburState _dottlerFollowDrilburState = new DottlerFollowDrilburState();

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        _currentState = _dottlerWanderState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        _currentState.UpdateState(this);
        
        if (!source.isPlaying)
        {
            if (waitTimer < 0f)
            {
                source.Play();
                waitTimer = UnityEngine.Random.Range(minWait, maxWait);
            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }

    }
    
    public void SwitchState(DottlerBaseState state)
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
