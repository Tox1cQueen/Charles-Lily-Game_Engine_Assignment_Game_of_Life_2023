using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DottlerBaseState
{
    public abstract void EnterState(DottlerStateManager dottler);

    public abstract void UpdateState(DottlerStateManager dottler);

    public abstract void OnTrig(DottlerStateManager dottler, Collider other);

    public abstract void OnTrigExit(DottlerStateManager dottler);
    
    public abstract void OnTrigStay(DottlerStateManager dottler, Collider other);
}
