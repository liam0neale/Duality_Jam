using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float m_levelLoadDelay = 1f;
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
        DimensionSwitcher.SwitchDimension(false);
        StartCoroutine(DelayLevelLoad());
    }

    public void ResetLevel()
    {
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
