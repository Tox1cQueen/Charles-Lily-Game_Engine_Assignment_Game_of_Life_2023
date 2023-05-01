using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZubatWanderState : ZubatBaseState
{
    private ZubatStateManager _stateManager;

    public override void EnterState(ZubatStateManager zubat)
    {
        zubat.StopAllCoroutines();
        zubat.StartCoroutine(PickNewTarget(zubat));
        zubat.isWandering = true;
        zubat.isFleeing = false;
    }

    public override void UpdateState(ZubatStateManager zubat)
    {
        zubat.rb.velocity = new Vector3(0, zubat.rb.velocity.y, 0);
        var step = zubat.speed * Time.deltaTime;
        zubat.transform.position = Vector3.MoveTowards(zubat.transform.position, zubat.wanderTarget, step);
        Debug.Log("In wander state rn");
    }

    public override void OnTrig(ZubatStateManager zubat, Collider other)
    {
    }

    public override void OnTrigExit(ZubatStateManager zubat) {}

    public override void OnTrigStay(ZubatStateManager zubat, Collider other)
    {
        if (other.tag == "Player")
        {
            zubat.StopCoroutine(PickNewTarget(zubat));
            zubat.SwitchState(zubat._zubatRunState);
            Debug.Log("Switching to Run state!");
        }

        if (other.tag == "Berry")
        {
            zubat.StopCoroutine(PickNewTarget(zubat));
            zubat.SwitchState(zubat._zubatFollowState);
            Debug.Log("Switching to Follow state!");
        }
    }
    

    IEnumerator PickNewTarget(ZubatStateManager zubat)
    {
        while (zubat.isWandering = true)
        {
            zubat.wanderTarget = new Vector3(Random.insideUnitSphere.x * 5, Mathf.Abs(Random.insideUnitSphere.y * 5) + 2, Random.insideUnitSphere.z * 5);
            Debug.Log("New target picked!");
            yield return new WaitForSeconds(1f);
        }
    }
}
