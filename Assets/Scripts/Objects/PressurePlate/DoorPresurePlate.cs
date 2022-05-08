using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPresurePlate : PressurePlate
{
    [SerializeField] private bool opensDoor = true;
    [SerializeField] private GameObject doorObject;
    private Door door;
    private AudioSource au;
    [SerializeField] AudioClip plateSound;

    void Start()
    {
        door = doorObject.GetComponent<Door>();
        au = GetComponent<AudioSource>();
    }

    protected override void PressurePlateDown()
    {
        au.PlayOneShot(plateSound);
        plate.PressurePlateDown();
        OpenCloseDoor(opensDoor);
    }

    protected override void PressurePlateUp()
    {
        plate.PressurePlateUp();
        OpenCloseDoor(!opensDoor);
    }

    private void OpenCloseDoor(bool open)
    {
        if (doorObject != null && (doorObject.GetComponent<DimensionalObject>() == null || (doorObject.GetComponent<DimensionalObject>().InCreepyDimension() == DimensionSwitcher.InCreepyDimension)))
        {
            if (open)
            {
                door.OpenDoor();
            }
            else
            {
                doorObject.SetActive(true);
            }
        }
    }
}
