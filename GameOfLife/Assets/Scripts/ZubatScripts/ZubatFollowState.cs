using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZubatFollowState : ZubatBaseState
{
    private ZubatStateManager _stateManager;

    public override void EnterState(ZubatStateManager zubat)
    {
        zubat.StopAllCoroutines();
    }

    public override void UpdateState(ZubatStateManager zubat)
    {
        zubat.rb.velocity = new Vector3(0, zubat.rb.velocity.y, 0);
        var step = zubat.speed * Time.deltaTime;
        zubat.transform.position = Vector3.MoveTowards(zubat.transform.position, zubat.player.position, step);
        Debug.Log("In following state rn");
    }

    public override void OnTrig(ZubatStateManager zubat, Collider other)
    {
    }

    public override void OnTrigExit(ZubatStateManager zubat)
    {
        zubat.SwitchState(zubat._zubatWanderState);
    }

    public override void OnTrigStay(ZubatStateManager zubat, Collider other)
    {
    }
    
}