using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburRunState : DrilburBaseState
{
    private DrilburStateManager _stateManager;

    public override void EnterState(DrilburStateManager drilbur)
    {
        Debug.Log("Run state active");
        drilbur.isWandering = false;
        drilbur.isFleeing = true;
        drilbur.StopAllCoroutines();
        drilbur.StartCoroutine(Flee(drilbur));
    }

    public override void UpdateState(DrilburStateManager drilbur)
    {

    }

    public override void OnTrig(DrilburStateManager drilbur, Collider other)
    {
    }


    public override void OnTrigExit(DrilburStateManager drilbur)
    {
        drilbur.StopCoroutine(Flee(drilbur));
        drilbur.SwitchState(drilbur._drilburWanderState);
    }

    IEnumerator Flee(DrilburStateManager drilbur)
    {
        while (drilbur.isFleeing = true)
        {
            Vector3 direction = drilbur.transform.position - drilbur.player.transform.position;
            direction.y = 0;
            drilbur.transform.Translate(direction.normalized * drilbur.speed * Time.deltaTime);
            Debug.Log("Fleeing!");
            yield return null;
        }
    }
}
