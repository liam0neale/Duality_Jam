using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] protected PlateMovement plate;
    private int nbObjectsOnPlate = 0;

    private List<GameObject> objectsOnPlate = new List<GameObject>();

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
        if (!objectsOnPlate.Contains(other.gameObject)) objectsOnPlate.Add(other.gameObject);
        SetState();
    }

    private void OnTriggerExit(Collider other)
    {
        DeleteObjectOnPlate(other.gameObject);
    }

    public void DeleteObjectOnPlate(GameObject obj)
    {
        if (objectsOnPlate.Contains(obj)) objectsOnPlate.Remove(obj);
        SetState();
    }

    private void SetState()
    {
        IsDown = (objectsOnPlate.Count > 0);
    }

    private void OnDisable()
    {
        objectsOnPlate.Clear();
    }

    private void OnEnable()
    {
        SetState();
    }
}
