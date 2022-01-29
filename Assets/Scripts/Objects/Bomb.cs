using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float timeBeforeExplosion;
    [SerializeField] private float timeBetweenTicks;
    [SerializeField] private float bombRange;
    [SerializeField] private GameObject explostionParticleEffect;

    [SerializeField] private Material normalMat;
    [SerializeField] private Material tickingMat;


    private bool timerStarted = false;
    private bool normMat = true;
    private float timeBeforeNextTick = 0;

    public void PlayerLetBombGo()
    {
        timerStarted = true;
        timeBeforeNextTick = timeBetweenTicks;
    }

    private void Explode()
    {
        // Explosion Audio


        // Check DestructableObjects
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, bombRange, transform.TransformDirection(Vector3.right));

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<DestructableObjects>() != null)
            {
                hit.collider.gameObject.GetComponent<DestructableObjects>().DestroyObject();
            }
        }

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
            timeBeforeNextTick -= Time.deltaTime;
            timeBeforeExplosion -= Time.deltaTime;

            if (timeBeforeNextTick <= 0)
            {
                timeBeforeNextTick = timeBetweenTicks;
                normMat = !normMat;
                GetComponent<MeshRenderer>().material = normMat ? normalMat : tickingMat;
            }

            if (timeBeforeExplosion <= 0)
            {
                Explode();
            }
        }
    }
}
