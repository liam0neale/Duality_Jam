using UnityEngine;

public class DimensionalObject : MonoBehaviour
{
    [SerializeField] private bool m_inCreepyDimension = false;

    private PhysicsPickUp m_playerPickup = default;

    private void Awake()
    {
        DimensionSwitcher.OnDimensionSwitched += OnDimensionSwitched;

        m_playerPickup = FindObjectOfType<PhysicsPickUp>();

        OnDimensionSwitched(DimensionSwitcher.InCreepyDimension);
    }

    private void OnDestroy()
    {
        DimensionSwitcher.OnDimensionSwitched -= OnDimensionSwitched;
    }

    private void OnDimensionSwitched(bool inCreepyDimension)
    {
        if (m_playerPickup != null && m_playerPickup.CarriedObject != null && m_playerPickup.CarriedObject == gameObject)
        {
            m_inCreepyDimension = inCreepyDimension;
        }

        if (gameObject.GetComponent<Door>() != null && !gameObject.GetComponent<Door>().DoorState)
        {
            //gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(m_inCreepyDimension == inCreepyDimension);
    }

    public bool InCreepyDimension()
    {
        return m_inCreepyDimension;
    }
}
