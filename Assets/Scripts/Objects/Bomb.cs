using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshToUse;
    [SerializeField] private float timeBeforeExplosion;
    [SerializeField] private float timeBetweenTicks;
    [SerializeField] private float bombRange;
    [SerializeField] private GameObject explostionParticleEffect;

    [SerializeField] private Material normalMat;
    [SerializeField] private Material tickingMat;


    private bool timerStarted = false;
    private bool normMat = true;
    private float timeBeforeNextTick = 0;

    private PressurePlate plate;

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
        GameObject smokePuff = Instantiate(explostionParticleEffect, transform.position, new Quaternion(0, 0, 0, 0) /*, transform.rotation*/) as GameObject;
        ParticleSystem parts = smokePuff.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
        Destroy(smokePuff, totalDuration);

        // Makes sure if colliding on pressure plate, it will turn off
        if (plate != null)
        {
            plate.DeleteObjectOnPlate(this.gameObject);
        }
        Destroy(this.gameObject);
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
                meshToUse.material = normMat ? normalMat : tickingMat;
            }

            if (timeBeforeExplosion <= 0)
            {
                Explode();
                timerStarted = false;
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PressurePlate>() != null)
        {
            plate = collision.gameObject.GetComponent<PressurePlate>();
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<PressurePlate>() != null && collision.gameObject.GetComponent<PressurePlate>() == plate)
        {
            plate = null;
        }
    }

}
