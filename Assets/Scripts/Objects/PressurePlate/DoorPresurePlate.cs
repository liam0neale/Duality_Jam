using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPresurePlate : PressurePlate
{
    [SerializeField] private bool opensDoor = true;
    [SerializeField] private GameObject doorObject;
    private Door door;

    void Start()
    {
        door = doorObject.GetComponent<Door>();
    }

    protected override void PressurePlateDown()
    {
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
