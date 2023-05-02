using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottlerFollowState : DottlerBaseState
{
    private DottlerStateManager _stateManager;

    public override void EnterState(DottlerStateManager dottler)
    {
        dottler.StopAllCoroutines();
    }

    public override void UpdateState(DottlerStateManager dottler)
    {
        dottler.rb.velocity = new Vector3(0, dottler.rb.velocity.y, 0);
        var step = dottler.speed * Time.deltaTime;
        Vector3 followPoint = new Vector3(dottler.player.position.x, 0,
            dottler.player.position.z + 2); 
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
    }
    
}