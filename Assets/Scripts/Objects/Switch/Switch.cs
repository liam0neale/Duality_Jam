using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool SwitchState
    {
        get
        {
            return switchState;
        }
        set
        {
            if (value != switchState)
            {
                if (value) SwitchedOn();
                if (!value) SwitchedOff();
            }
            switchState = value;
        }
    }
    bool switchState = false;

    protected virtual void SwitchedOn()
    {

    }

    protected virtual void SwitchedOff()
    {

    }
}
