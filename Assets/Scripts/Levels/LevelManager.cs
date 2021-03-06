using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float m_levelLoadDelay = 1f;
    [SerializeField] private Level[] m_levelPrefabs;
    [SerializeField] private GameObject m_playerDead;

    private PlayerController m_player = null;

    private Level m_currentLevelInstance = null;
    private int m_currentLevelIndex = 0;

    bool m_loadedFirstLevel = false;

    private void Awake()
    {
        m_player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if(!m_loadedFirstLevel)
        {
            m_currentLevelIndex = -1;
            LoadNextLevel();
            m_loadedFirstLevel = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void HandleLevelComplete()
    {
        DimensionSwitcher.SwitchDimension(false);
        StartCoroutine(DelayLevelLoad());
    }

    public void ResetLevel(bool complete)
    {
        if (!complete)
        {
            StartCoroutine(PlayerDeathEffect());
            return;
        }

        if (m_currentLevelInstance != null)
        {
            Destroy(m_currentLevelInstance.gameObject);
        }

        m_currentLevelInstance = Instantiate(m_levelPrefabs[m_currentLevelIndex]);
        FindObjectOfType<PhysicsPickUp>().ResetCarried();
    }

    private IEnumerator PlayerDeathEffect()
    {
        m_player.gameObject.SetActive(false);
        GameObject obj = Instantiate(m_playerDead, m_player.gameObject.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(m_levelLoadDelay);

        Destroy(obj);
        m_player.gameObject.SetActive(true);

        if (m_currentLevelInstance != null)
        {
            Destroy(m_currentLevelInstance.gameObject);
        }

        m_currentLevelInstance = Instantiate(m_levelPrefabs[m_currentLevelIndex]);
        FindObjectOfType<PhysicsPickUp>().ResetCarried();
    }

    private IEnumerator DelayLevelLoad()
    {
        yield return new WaitForSeconds(m_levelLoadDelay);

        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        m_currentLevelIndex++;

        if (m_currentLevelIndex >= m_levelPrefabs.Length)
        {
            SceneController.LoadGameOver();
            return;
        }

        if (m_currentLevelInstance != null)
        {
            Destroy(m_currentLevelInstance.gameObject);
        }

        m_currentLevelInstance = Instantiate(m_levelPrefabs[m_currentLevelIndex]);
        m_currentLevelInstance.Camera.LookAt = m_player.transform;
    }
}
