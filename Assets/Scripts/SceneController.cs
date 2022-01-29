using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    const int LEVEL_1_INDEX = 1;
    static int CurrentSceneIndex = 0;
    
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
    public static void LoadWinMenu()
    {
        SceneManager.LoadScene("WinMenu");
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadDeathMenu()
    {
        SceneManager.LoadScene("DeathMenu");
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public static void LoadNextLevel()
    {
        CurrentSceneIndex++;
        if (IndexInRange() == false)
            return;
        
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public static void LoadLevel(int _levelIndex)
    {
        CurrentSceneIndex = _levelIndex;
        if (IndexInRange() == false)
            return;
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    public static void LoadFirstLevel()
    {
        LoadLevel(LEVEL_1_INDEX);
    }


    static bool IndexInRange()
    {
        if (CurrentSceneIndex >= SceneManager.sceneCount + 1)
        {
            Debug.LogError("SceneController::IndexInRange() -> index is out of range : index = " + CurrentSceneIndex.ToString());
            return false;
        }
        return true;
    }
}
