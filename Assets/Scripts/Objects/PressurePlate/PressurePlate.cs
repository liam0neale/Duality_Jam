using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] PlateMovement plate;

    public bool IsDown
    {
        get
        {
            return isDown;
        }
        set
        {
            if (value != isDown)
            {
                if (value)
                {
                    PressurePlateDown();
                }
                else
                {
                    PressurePlateUp();
                }
            }

            isDown = value;
        }
    }
    private bool isDown;


    protected virtual void PressurePlateDown()
    {
        plate.PressurePlateDown();
    }

    protected virtual void PressurePlateUp()
    {
        plate.PressurePlateUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsDown = false;
        }
    }
}
