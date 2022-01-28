using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitch : Switch
{
    public void SwitchDimension()
    {
        SwitchState = !SwitchState;
    }

    protected override void SwitchedOn()
    {
        // Going to dark dimension
    }

    protected override void SwitchedOff()
    {
        // Going to normal dimension
    }

}
