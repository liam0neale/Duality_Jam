using UnityEngine;
using Cinemachine;

public class Level : MonoBehaviour
{
    public CinemachineVirtualCamera Camera => m_camera;

    [SerializeField] Transform m_playerStartingPosition = default;
    [SerializeField] private float m_darkTimer;//timer to complete dark side in
    [SerializeField] private CinemachineVirtualCamera m_camera = default;

    private CharacterController m_playerController;

    public void ResetLevel()
    {
        m_playerController.enabled = false;
        m_playerController.transform.position = m_playerStartingPosition.position;
        m_playerController.transform.rotation = m_playerStartingPosition.rotation;
        m_playerController.enabled = true;

        if (Manager.m_counter != null && m_darkTimer != 0)
        {
            m_camera.LookAt = m_playerController.transform;
            Manager.m_counter.SetTimeLimit(m_darkTimer);
        }
    }

    private void Awake()
    {
        m_playerController = FindObjectOfType<CharacterController>();

        ResetLevel();
    }
}
