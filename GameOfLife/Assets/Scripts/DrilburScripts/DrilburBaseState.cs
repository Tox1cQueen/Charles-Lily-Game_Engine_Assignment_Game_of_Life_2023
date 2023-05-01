using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrilburBaseState
{
    public abstract void EnterState(DrilburStateManager drilbur);

    public abstract void UpdateState(DrilburStateManager drilbur);

    public abstract void OnTrig(DrilburStateManager drilbur, Collider other);

    public abstract void OnTrigExit(DrilburStateManager drilbur);
    
    public abstract void OnTrigStay(DrilburStateManager drilbur, Collider other);
}
