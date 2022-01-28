using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int doorKey;
    [SerializeField] private GameObject doorOpenningParticleEffect;

    public bool TryOpenDoor(int key)
    {
        if (key == doorKey)
        {
            OpenDoor();
            return true;
        }
        return false;
    }

    public void OpenDoor()
    {
        // Openning Door Audio (TODO)

        // Particle System
        GameObject smokePuff = Instantiate(doorOpenningParticleEffect, transform.position, transform.rotation) as GameObject;
        ParticleSystem parts = smokePuff.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
        Destroy(smokePuff, totalDuration);

        // Destroy Door
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Key>() != null)
        {
            Key key = collision.collider.gameObject.GetComponent<Key>();
            if (TryOpenDoor(key.KeyNumber))
            {
                key.DestroyKey();
            }
        }
    }
}
