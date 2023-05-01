using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburWanderState : DrilburBaseState
{
    private DrilburStateManager _stateManager;
    private DottlerStateManager _dottlerStateManager;

    public override void EnterState(DrilburStateManager drilbur)
    {
        drilbur.StopAllCoroutines();
        drilbur.StartCoroutine(PickNewTarget(drilbur));
        drilbur.isWandering = true;
        drilbur.isFleeing = false;
    }

    public override void UpdateState(DrilburStateManager drilbur)
    {
        drilbur.rb.velocity = new Vector3(0, drilbur.rb.velocity.y, 0);
        var step = drilbur.speed * Time.deltaTime;
        drilbur.transform.position = Vector3.MoveTowards(drilbur.transform.position, drilbur.wanderTarget, step);
        Debug.Log("In wander state rn");

        if (_dottlerStateManager.followingDrilbur == true)
        {
            drilbur.speed = 0.5f;
        }

    }

    public override void OnTrig(DrilburStateManager drilbur, Collider other)
    {
    }

    public override void OnTrigExit(DrilburStateManager drilbur) {}

    public override void OnTrigStay(DrilburStateManager drilbur, Collider other)
    {
        if (other.tag == "Player")
        {
            drilbur.StopCoroutine(PickNewTarget(drilbur));
            drilbur.largeSphereTrigger.enabled = true;
            drilbur.smallSphereTrigger.enabled = false;
            drilbur.SwitchState(drilbur._drilburRunState);
            Debug.Log("Switching to Run state!");
        }

        if (other.tag == "Berry")
        {
            drilbur.StopCoroutine(PickNewTarget(drilbur));
            drilbur.SwitchState(drilbur._drilburFollowState);
            Debug.Log("Switching to Follow state!");
        }
        
        if (other.tag == "Dottler")
        {
            Debug.Log("Dottler found");
            drilbur.speed = 1.4f;
        }
    }
    

    IEnumerator PickNewTarget(DrilburStateManager drilbur)
    {
        while (drilbur.isWandering = true)
        {
            drilbur.wanderTarget = new Vector3(Random.insideUnitSphere.x * 5, 1, Random.insideUnitSphere.z * 5);
            Debug.Log("New target picked!");
            yield return new WaitForSeconds(3f);
        }
    }
}
