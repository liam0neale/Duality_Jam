using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjects : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
