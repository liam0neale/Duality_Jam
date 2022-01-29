using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] m_levelPrefabs;

    private Level m_currentLevelInstance = null;
    private int m_currentLevelIndex = 0;

    private void Awake()
    {
        m_currentLevelIndex = -1;
        LoadNextLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetLevel();
        }
    }

    public void HandleLevelComplete()
    {
        LoadNextLevel();
    }

    public void ResetLevel()
    {
        m_currentLevelInstance.ResetLevel();
    }

    private void LoadNextLevel()
    {
        m_currentLevelIndex++;

        if (m_currentLevelIndex >= m_levelPrefabs.Length)
        {
            // TODO: Load Main Menu 
            return;
        }

        if (m_currentLevelInstance != null)
        {
            Destroy(m_currentLevelInstance.gameObject);
        }

        m_currentLevelInstance = Instantiate(m_levelPrefabs[m_currentLevelIndex]);
    }
}
