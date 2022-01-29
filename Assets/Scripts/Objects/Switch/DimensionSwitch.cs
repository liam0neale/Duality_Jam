public class DimensionSwitch : Switch
{
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
