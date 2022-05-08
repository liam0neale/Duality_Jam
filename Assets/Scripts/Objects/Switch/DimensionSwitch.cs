using UnityEngine;

public class DimensionSwitch : Switch
{
    [SerializeField] private AudioSource au;
    [SerializeField] private AudioClip switchToDimensionSound;
    [SerializeField] private AudioClip switchBackDimensionSound;

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

        if (au.isPlaying)
        {
            au.Stop();
        }

        au.PlayOneShot(switchToDimensionSound);
    }

    protected override void SwitchedOff()
    {
        DimensionSwitcher.SwitchDimension(!DimensionSwitcher.InCreepyDimension);
        if (au.isPlaying) au.Stop();
        au.PlayOneShot(switchBackDimensionSound);
    }
}