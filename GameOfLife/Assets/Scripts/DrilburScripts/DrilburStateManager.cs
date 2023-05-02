using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrilburStateManager : MonoBehaviour
{
    public Transform drilburTransform;
    public Transform player;
    public float speed;
    public Vector3 wanderTarget;
    public bool isWandering;
    public bool isFleeing;
    public Rigidbody rb;
    public Collider smallSphereTrigger;
    public Collider largeSphereTrigger;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWait = 5f;
    public float maxWait = 40f;
    public float waitTimer = -2f;
    
    private DrilburBaseState _currentState;
    public DrilburFollowState _drilburFollowState = new DrilburFollowState();
    public DrilburRunState _drilburRunState = new DrilburRunState();
    public DrilburWanderState _drilburWanderState = new DrilburWanderState();
    

    // Start is called before the first frame update
    void Start()
    {
        var randomScale = Random.Range(1f, 15f);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        source = GetComponent<AudioSource>();
        _currentState = _drilburWanderState;
        _currentState.EnterState(this);
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
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
