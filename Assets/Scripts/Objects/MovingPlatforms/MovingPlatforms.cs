using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float changeDirectionDelay;


    private Transform destinationTarget, departTarget;

    private float startTime;

    private float journeyLength;

    bool isWaiting;

    [SerializeField]
    bool isEnabled;



    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }


    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        if (isEnabled)
        {
            if (!isWaiting)
            {
                if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
                {
                    float distCovered = (Time.time - startTime) * speed;

                    float fractionOfJourney = distCovered / journeyLength;

                    transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
                }
                else
                {
                    isWaiting = true;
                    StartCoroutine(changeDelay());
                }
            }


        }
    }

    void ChangeDestination()
    {

        if (departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }

    }
    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }

   public void Test(bool enable)
    {
        isEnabled = enable;
        startTime = Time.time;
    }

          // if (other.gameObject.tag == "Player" || other.gameObject.tag == "Moveable")
                   //if (other.gameObject.transform.parent == null || other.gameObject.transform.parent.parent == null || (other.gameObject.transform.parent.parent.tag != "Player")|| other.gameObject.tag == "Moveable")
            
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        { 
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }

    }

}
