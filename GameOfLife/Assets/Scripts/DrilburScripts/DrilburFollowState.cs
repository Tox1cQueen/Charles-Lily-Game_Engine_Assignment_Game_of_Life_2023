using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburFollowState : DrilburBaseState
{
    private DrilburStateManager _stateManager;

    public override void EnterState(DrilburStateManager drilbur)
    {
        drilbur.StopAllCoroutines();
    }

    public override void UpdateState(DrilburStateManager drilbur)
    {
        drilbur.rb.velocity = new Vector3(0, drilbur.rb.velocity.y, 0);
        var step = drilbur.speed * Time.deltaTime;
        drilbur.transform.position = Vector3.MoveTowards(drilbur.transform.position, drilbur.player.position, step);
    }

    public override void OnTrig(DrilburStateManager drilbur, Collider other)
    {
    }

    public override void OnTrigExit(DrilburStateManager drilbur)
    {
        drilbur.SwitchState(drilbur._drilburWanderState);
    }

    public override void OnTrigStay(DrilburStateManager drilbur, Collider other)
    {
    }
    
}