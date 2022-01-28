using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PhysicsPickUp : MonoBehaviour
{
    public GameObject CarriedObject => CurrentObject == null ? null : CurrentObject.gameObject;

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }


            if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit HitInfo, 20f))
            {
                Debug.Log("Hit something");
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
            else 
            {
                Debug.Log("Hit nothing");
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
