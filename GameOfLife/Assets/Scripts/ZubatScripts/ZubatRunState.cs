using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZubatRunState : ZubatBaseState
{
    private ZubatStateManager _stateManager;

    public override void EnterState(ZubatStateManager zubat)
    {
        Debug.Log("Run state active");
        zubat.isWandering = false;
        zubat.isFleeing = true;
        zubat.StopAllCoroutines();
        zubat.StartCoroutine(Flee(zubat));
    }

    public override void UpdateState(ZubatStateManager zubat)
    {
        zubat.rb.velocity = new Vector3(0, zubat.rb.velocity.y, 0);
    }

    public override void OnTrig(ZubatStateManager zubat, Collider other)
    {
    }


    public override void OnTrigExit(ZubatStateManager zubat)
    {
        zubat.StopCoroutine(Flee(zubat));
        zubat.SwitchState(zubat._zubatWanderState);
    }

    public override void OnTrigStay(ZubatStateManager zubat, Collider other)
    {
        
    }

    IEnumerator Flee(ZubatStateManager zubat)
    {
        while (zubat.isFleeing = true)
        {
            Vector3 direction = zubat.transform.position - zubat.player.transform.position;
            direction.y = 0;
            zubat.transform.Translate(direction.normalized * zubat.speed * Time.deltaTime);
            Debug.Log("Fleeing!");
            yield return null;
        }
    }
}
