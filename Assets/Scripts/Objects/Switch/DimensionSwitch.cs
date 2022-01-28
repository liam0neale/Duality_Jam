public class DimensionSwitch : Switch
{
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
