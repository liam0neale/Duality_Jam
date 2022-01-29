using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int doorKey;
    [SerializeField] private GameObject doorOpenningParticleEffect;
    [SerializeField] private GameObject doorClosingParticleEffect;
    [SerializeField] private bool firstCall = true;

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
        OpenningAndClosingDoorParticleEffect();

        // Set Door to inactive
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
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

    private void OnEnable()
    {
        if (firstCall)
        {
            firstCall = false;
            return;
        }
        OpenningAndClosingDoorParticleEffect(false);
    }

    private void OpenningAndClosingDoorParticleEffect(bool openning = true)
    {
        // Particle System
        GameObject smokePuff = Instantiate((openning ? doorOpenningParticleEffect : doorClosingParticleEffect), transform.position, transform.rotation) as GameObject;
        ParticleSystem parts = smokePuff.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
        Destroy(smokePuff, totalDuration);
    }
}
