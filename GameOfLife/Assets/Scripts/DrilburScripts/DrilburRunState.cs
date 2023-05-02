using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburRunState : DrilburBaseState
{
    private DrilburStateManager _stateManager;

    public override void EnterState(DrilburStateManager drilbur)
    {
        drilbur.isWandering = false;
        drilbur.isFleeing = true;
        drilbur.StopAllCoroutines();
        drilbur.StartCoroutine(Flee(drilbur));
    }

    public override void UpdateState(DrilburStateManager drilbur)
    {
        drilbur.rb.velocity = new Vector3(0, drilbur.rb.velocity.y, 0);
    }

    public override void OnTrig(DrilburStateManager drilbur, Collider other)
    {
    }


    public override void OnTrigExit(DrilburStateManager drilbur)
    {
        drilbur.StopCoroutine(Flee(drilbur));
        drilbur.largeSphereTrigger.enabled = false;
        drilbur.smallSphereTrigger.enabled = true;
        drilbur.SwitchState(drilbur._drilburWanderState);
    }

    public override void OnTrigStay(DrilburStateManager drilbur, Collider other)
    {
        
    }

    IEnumerator Flee(DrilburStateManager drilbur)
    {
        while (drilbur.isFleeing = true)
        {
            Vector3 direction = drilbur.transform.position - drilbur.player.transform.position;
            direction.y = 0;
            drilbur.transform.Translate(direction.normalized * drilbur.speed * Time.deltaTime);
            drilbur.speed = 4f;
            yield return null;
        }
    }
}
