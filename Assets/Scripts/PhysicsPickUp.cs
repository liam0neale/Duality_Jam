using UnityEngine;
public class PhysicsPickUp : MonoBehaviour
{
    public GameObject CarriedObject { get; private set; } = null;

    [SerializeField] private LayerMask m_interactableMask = default;
    [SerializeField] private Transform m_pickupTarget = default;
    [SerializeField] private float m_pickupRange = 10;

    private Transform m_previousParent;

    public void ResetCarried()
    {
        m_previousParent = null;

        Destroy(CarriedObject);
        CarriedObject = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool skipDrop = false;

            Collider[] interactables = Physics.OverlapSphere(m_pickupTarget.position, m_pickupRange, m_interactableMask);
            foreach (Collider interactable in interactables)
            {
                if (interactable.gameObject == CarriedObject)
                {
                    continue;
                }

                if (interactable.gameObject.GetComponent<Switch>() != null)
                {
                    interactable.gameObject.GetComponent<Switch>().FlipState();
                    skipDrop = true;
                }
                else if (CarriedObject == null)
                {
                    m_previousParent = interactable.transform.parent;

                    interactable.transform.parent = m_pickupTarget;
                    interactable.transform.position = m_pickupTarget.position;
                    interactable.transform.rotation = m_pickupTarget.rotation;

                    CarriedObject = interactable.gameObject;
                    skipDrop = true;
                }
            }

            if (skipDrop)
            {
                return;
            }

            if (CarriedObject != null)
            {
                if (CarriedObject.GetComponent<Bomb>() != null)
                {
                    CarriedObject.GetComponent<Bomb>().PlayerLetBombGo();
                }

                CarriedObject.transform.parent = m_previousParent;
                m_previousParent = null;
                CarriedObject = null;
            }
        }
    }
}