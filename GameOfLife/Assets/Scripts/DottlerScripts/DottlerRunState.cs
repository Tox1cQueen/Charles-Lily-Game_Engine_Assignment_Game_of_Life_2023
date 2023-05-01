using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottlerRunState : DottlerBaseState
{
    private DottlerStateManager _stateManager;

    public override void EnterState(DottlerStateManager dottler)
    {
        Debug.Log("Run state active");
        dottler.isWandering = false;
        dottler.isFleeing = true;
        dottler.StopAllCoroutines();
        dottler.StartCoroutine(Flee(dottler));
    }

    public override void UpdateState(DottlerStateManager dottler)
    {
        dottler.rb.velocity = new Vector3(0, dottler.rb.velocity.y, 0);
    }

    public override void OnTrig(DottlerStateManager dottler, Collider other)
    {
    }


    public override void OnTrigExit(DottlerStateManager dottler)
    {
        dottler.StopCoroutine(Flee(dottler));
        dottler.SwitchState(dottler._dottlerWanderState);
    }

    public override void OnTrigStay(DottlerStateManager dottler, Collider other)
    {
        
    }

    IEnumerator Flee(DottlerStateManager dottler)
    {
        while (dottler.isFleeing = true)
        {
            Vector3 direction = dottler.transform.position - dottler.player.transform.position;
            direction.y = 0;
            dottler.transform.Translate(direction.normalized * dottler.speed * Time.deltaTime);
            Debug.Log("Fleeing!");
            yield return null;
        }
    }
}
