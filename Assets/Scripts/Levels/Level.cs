using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform m_playerStartingPosition = default;

    private CharacterController m_playerController;
    [SerializeField] private float m_darkTimer;//timer to complete dark side in

    public void ResetLevel()
    {
        m_playerController.enabled = false;
        m_playerController.transform.position = m_playerStartingPosition.position;
        m_playerController.transform.rotation = m_playerStartingPosition.rotation;
        m_playerController.enabled = true;
        
        if(Manager.m_counter != null && m_darkTimer != 0)
            Manager.m_counter.SetTimeLimit(m_darkTimer);
    }

    private void Awake()
    {
        m_playerController = FindObjectOfType<CharacterController>();

        ResetLevel();
    }
}
