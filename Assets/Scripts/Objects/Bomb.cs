using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float timeBeforeExplosion;
    [SerializeField] private float bombRange;
    [SerializeField] private GameObject explostionParticleEffect;


    private bool timerStarted = false;

    public void PlayerLetBombGo()
    {
        timerStarted = true;
    }

    private void Explode()
    {
        // Explosion Audio


        // Check DestructableObjects
        CheckDirection(Vector3.forward);
        CheckDirection(Vector3.back);
        CheckDirection(Vector3.left);
        CheckDirection(Vector3.right);
        CheckDirection(new Vector3(1, 0, 1));
        CheckDirection(new Vector3(-1, 0, 1));
        CheckDirection(new Vector3(-1, 0, -1));
        CheckDirection(new Vector3(1, 0, -1));

        // Particle System
        GameObject smokePuff = Instantiate(explostionParticleEffect, transform.position, transform.rotation) as GameObject;
        ParticleSystem parts = smokePuff.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
        Destroy(smokePuff, totalDuration);

        Destroy(this.gameObject);
    }

    private void CheckDirection(Vector3 dir)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(dir), bombRange);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<DestructableObjects>() != null)
            {
                hit.collider.gameObject.GetComponent<DestructableObjects>().DestroyObject();
            }
        }
    }

    void Update()
    {
        if (timerStarted)
        {
            timeBeforeExplosion -= Time.deltaTime;
            if (timeBeforeExplosion <= 0)
            {
                Explode();
            }
        }
    }
}
