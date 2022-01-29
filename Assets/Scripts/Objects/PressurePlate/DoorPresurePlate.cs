using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPresurePlate : PressurePlate
{
    [SerializeField] private GameObject doorObject;
    private Door door;

    void Start()
    {
        door = doorObject.GetComponent<Door>();
    }

    protected override void PressurePlateDown()
    {
        plate.PressurePlateDown();
        if (doorObject != null) door.OpenDoor();
    }

    protected override void PressurePlateUp()
    {
        plate.PressurePlateUp();
        if (doorObject != null) doorObject.SetActive(true);
    }
}
