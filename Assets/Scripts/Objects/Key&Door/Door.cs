using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool lastDoor = true;
    [SerializeField] private int doorKey;
    [SerializeField] private GameObject doorOpenningParticleEffect;
    [SerializeField] private GameObject doorClosingParticleEffect;
    [SerializeField] private bool firstCall = true;

    public bool DoorState
    {
        get
        {
            return doorState;
        }
        private set
        {
            doorState = value;
        }
    }
    private bool doorState = false;

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
        doorState = false;
        if (lastDoor) FindObjectOfType<LevelManager>().HandleLevelComplete();

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
        doorState = true;
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
