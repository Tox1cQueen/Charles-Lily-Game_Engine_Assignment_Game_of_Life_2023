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
        Vector3 targetDirection = zubat.wanderTarget - zubat.transform.position;
        zubat.transform.position = Vector3.MoveTowards(zubat.transform.position, zubat.wanderTarget, step);
        zubat.transform.rotation = Quaternion.Slerp(zubat.transform.rotation,Quaternion.LookRotation(targetDirection), Time.deltaTime * 10f);
    }

    public override void OnTrig(ZubatStateManager zubat, Collider other)
    {
    }

    public override void OnTrigExit(ZubatStateManager zubat) {}

    public override void OnTrigStay(ZubatStateManager zubat, Collider other)
    {
    }
    

    IEnumerator PickNewTarget(ZubatStateManager zubat)
    {
        while (zubat.isWandering = true)
        {
            zubat.wanderTarget = new Vector3(zubat.transform.position.x + Random.insideUnitSphere.x * 15, Mathf.Abs(Random.insideUnitSphere.y * 5) + 2,zubat.transform.position.z + Random.insideUnitSphere.z * 15);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
