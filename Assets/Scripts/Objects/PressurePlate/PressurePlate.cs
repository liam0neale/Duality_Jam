using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] protected PlateMovement plate;
    private int nbObjectsOnPlate = 0;

    public bool IsDown
    {
        get
        {
            return isDown;
        }
        private set
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
        nbObjectsOnPlate++;
        SetState();
    }

    private void OnTriggerExit(Collider other)
    {
        nbObjectsOnPlate--;
        SetState();
    }

    public void DeleteObjectOnPlate()
    {
        nbObjectsOnPlate--;
        SetState();
    }

    private void SetState()
    {
        IsDown = (nbObjectsOnPlate > 0);
    }
}
