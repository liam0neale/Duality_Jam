using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float m_switchingDelay = 2f;
    [SerializeField] private GameObject m_spikesShownObject = default;

    private float m_switchingTimer = 0;

    private void Awake()
    {
        m_spikesShownObject.SetActive(false);
    }

    private void Update()
    {
        m_switchingTimer += Time.deltaTime;

        if (m_switchingTimer >= m_switchingDelay)
        {
            m_spikesShownObject.SetActive(!m_spikesShownObject.activeSelf);
            m_switchingTimer = 0;
        }
    }
}
