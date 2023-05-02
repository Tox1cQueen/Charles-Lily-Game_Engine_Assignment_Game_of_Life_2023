using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottlerFollowDrilburState : DottlerBaseState
{
    private DottlerStateManager _stateManager;
    private DrilburStateManager _drilburStateManager;
    public override void EnterState(DottlerStateManager dottler)
    {
        dottler.StopAllCoroutines();
        dottler.followingDrilbur = true;
    }

    public override void UpdateState(DottlerStateManager dottler)
    {
        dottler.rb.velocity = new Vector3(0, dottler.rb.velocity.y, 0);
        var step = dottler.speed * Time.deltaTime;
        Vector3 followPoint = new Vector3(dottler.drilbur.position.x - 2, dottler.drilbur.position.y,
            dottler.drilbur.position.z - 2); 
        dottler.transform.position = Vector3.MoveTowards(dottler.transform.position, followPoint, step);
    }

    public override void OnTrig(DottlerStateManager dottler, Collider other)
    {
    }

    public override void OnTrigExit(DottlerStateManager dottler)
    {
        dottler.SwitchState(dottler._dottlerWanderState);
    }

    public override void OnTrigStay(DottlerStateManager dottler, Collider other)
    {
        if (other.tag == "Player")
        {
            dottler.SwitchState(dottler._dottlerFollowState);
        }
    }
    
}