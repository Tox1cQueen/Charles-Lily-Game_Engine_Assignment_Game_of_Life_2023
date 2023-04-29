using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrilburWanderState : DrilburBaseState
{
    private DrilburStateManager _stateManager;

    public override void EnterState(DrilburStateManager drilbur)
    {
        drilbur.StartCoroutine(PickNewTarget(drilbur));
        drilbur.isWandering = true;
    }

    public override void UpdateState(DrilburStateManager drilbur)
    {
        var step = drilbur.speed * Time.deltaTime;
        drilbur.transform.position = Vector3.MoveTowards(drilbur.transform.position, drilbur.wanderTarget, step);
    }
    
    public override void OnTrig(DrilburStateManager drilbur, Collider other) {}

    public override void OnTrigExit(DrilburStateManager drilbur) {}

    IEnumerator PickNewTarget(DrilburStateManager drilbur)
    {
        while (drilbur.isWandering = true)
        {
            drilbur.wanderTarget = new Vector3(Random.insideUnitSphere.x * 5, 1, Random.insideUnitSphere.z * 5);
            Debug.Log("New target picked!");
            yield return new WaitForSeconds(3f);
        }
    }
}
