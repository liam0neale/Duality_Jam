using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMovement : MonoBehaviour
{
    Transform pressurePlate;
    Vector3 defaultPosition;

    void Start()
    {
        pressurePlate = this.transform;
        defaultPosition = pressurePlate.position;
    }

    public void PressurePlateDown()
    {
        pressurePlate.position = new Vector3(defaultPosition.x, defaultPosition.y - 0.1f, defaultPosition.z);
    }

    public void PressurePlateUp()
    {
        pressurePlate.position = defaultPosition;
    }
}
