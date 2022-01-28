using UnityEngine;

public class DimensionalObject : MonoBehaviour
{
    [SerializeField] private bool m_inCreepyDimension = false;

    private void Awake()
    {
        DimensionSwitcher.OnDimensionSwitched += OnDimensionSwitched;
    }

    private void OnDimensionSwitched(bool inCreepyDimension)
    {
        gameObject.SetActive(m_inCreepyDimension == inCreepyDimension);
    }
}
