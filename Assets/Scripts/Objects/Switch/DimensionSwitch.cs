using UnityEngine;

public class DimensionSwitch : Switch
{
    private AudioSource au;
    [SerializeField] private AudioClip switchToDimensionSound;
    [SerializeField] private AudioClip switchBackDimensionSound;

    private void Awake()
    {
        SwitchState = DimensionSwitcher.InCreepyDimension;
        UpdateModel();
    }

    private void Start()
    {
        au = GetComponent<AudioSource>();
    }

    public void SwitchDimension()
    {
        SwitchState = !DimensionSwitcher.InCreepyDimension;
    }

    protected override void SwitchedOn()
    {
        if (au.isPlaying) au.Stop();
        au.PlayOneShot(switchToDimensionSound);
        DimensionSwitcher.SwitchDimension(!DimensionSwitcher.InCreepyDimension);
    }

    protected override void SwitchedOff()
    {
        if (au.isPlaying) au.Stop();
        au.PlayOneShot(switchBackDimensionSound);
        DimensionSwitcher.SwitchDimension(!DimensionSwitcher.InCreepyDimension);
    }
}