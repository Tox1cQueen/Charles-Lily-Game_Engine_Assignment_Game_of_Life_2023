using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZubatBaseState
{
    public abstract void EnterState(ZubatStateManager zubat);

    public abstract void UpdateState(ZubatStateManager zubat);

    public abstract void OnTrig(ZubatStateManager zubat, Collider other);

    public abstract void OnTrigExit(ZubatStateManager zubat);
    
    public abstract void OnTrigStay(ZubatStateManager zubat, Collider other);
}
