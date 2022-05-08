using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformSwitch : Switch
{
    [SerializeField] private bool movePlatform = true;
    [SerializeField] private GameObject platformObject;
    private MovingPlatforms platform;
    private void Awake()
    {
        platform = platformObject.GetComponent<MovingPlatforms>();
    }

    protected override void SwitchedOn()
    {
        EnablePlatform(movePlatform);
    }

    protected override void SwitchedOff()
    {
        EnablePlatform(!movePlatform);
    }

    private void EnablePlatform(bool enable)
    {
        if(platformObject != null)
        {
            if (enable)
            {
                platform.Test(true);
            }
            else
            {
                platform.Test(false);
            }
        }
    }

}
