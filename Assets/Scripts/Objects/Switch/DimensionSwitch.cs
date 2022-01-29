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
        SwitchState = !DimensionSwitcher.InCreepyDimension;
    }

    protected override void SwitchedOn()
    {
        DimensionSwitcher.SwitchDimension(!DimensionSwitcher.InCreepyDimension);
    }

    protected override void SwitchedOff()
    {
        DimensionSwitcher.SwitchDimension(!DimensionSwitcher.InCreepyDimension);
    }
}