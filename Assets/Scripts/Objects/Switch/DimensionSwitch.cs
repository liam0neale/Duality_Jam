using UnityEngine;

public class DimensionSwitch : Switch
{
    private void Awake()
    {
        SwitchState = DimensionSwitcher.InCreepyDimension;
        UpdateModel();
    }

    public void SwitchDimension()
    {
        SwitchState = !SwitchState;
    }

    protected override void SwitchedOn()
    {
        DimensionSwitcher.SwitchDimension(true);
    }

    protected override void SwitchedOff()
    {
        DimensionSwitcher.SwitchDimension(false);
    }
}