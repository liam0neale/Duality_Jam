using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int KeyNumber
    {
        get
        {
            return keyNb;
        }
        set
        {
            Debug.LogError("KeyNumber cannot be set after scene");
        }
    }

    [SerializeField] private int keyNb;

    public void DestroyKey()
    {
        Destroy(this.gameObject);
    }
}
