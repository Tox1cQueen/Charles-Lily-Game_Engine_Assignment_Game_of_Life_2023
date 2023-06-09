using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottlerWanderState : DottlerBaseState
{
    private DottlerStateManager _stateManager;
    private DrilburStateManager _drilburStateManager;

    public override void EnterState(DottlerStateManager dottler)
    {
        dottler.StopAllCoroutines();
        dottler.StartCoroutine(PickNewTarget(dottler));
        dottler.isWandering = true;
        dottler.isFleeing = false;
    }

    public override void UpdateState(DottlerStateManager dottler)
    {
        dottler.rb.velocity = new Vector3(0, dottler.rb.velocity.y, 0);
        var step = dottler.speed * Time.deltaTime;
        dottler.transform.position = Vector3.MoveTowards(dottler.transform.position, dottler.wanderTarget, step);
    }

    public override void OnTrig(DottlerStateManager dottler, Collider other)
    {
    }

    public override void OnTrigExit(DottlerStateManager dottler) {}

    public override void OnTrigStay(DottlerStateManager dottler, Collider other)
    {
        if (other.tag == "Player")
        {
            dottler.StopCoroutine(PickNewTarget(dottler));
            dottler.SwitchState(dottler._dottlerFollowState);
        }

        if (other.tag == "Drilbur")
        {
            dottler.StopCoroutine(PickNewTarget(dottler));
            dottler.SwitchState(dottler._dottlerFollowDrilburState);
            _drilburStateManager.speed = 0.5f;
        }
    }
    

    IEnumerator PickNewTarget(DottlerStateManager dottler)
    {
        while (dottler.isWandering = true)
        {
            dottler.wanderTarget = new Vector3(dottler.transform.position.x + Random.insideUnitSphere.x * 5, 0, dottler.transform.position.z + Random.insideUnitSphere.z * 5);
            yield return new WaitForSeconds(3f);
        }
    }
}
