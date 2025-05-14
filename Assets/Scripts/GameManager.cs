using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Game Manager
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameManagerCheck()
    {
        // Debug.Log("GameManager Check");
    }
    #endregion

    #region Game Management
    public bool isPaused;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region Level Manager
    [System.Serializable]
    public class LevelData
    {
        public int level;
    }

    private LevelData levelData;
    public int levelCurrent;

    private string levelDataPath => Path.Combine(Application.persistentDataPath, "Level.json");

    public void CheckSaveFile()
    {
        if (File.Exists(levelDataPath))
        {
            LoadLevel();
        }
        else
        {
            SaveLevel();
        }
    }

    private void SaveLevel()
    {
        levelData = new LevelData { level = levelCurrent };
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(levelDataPath, json);
    }

    private void LoadLevel()
    {
        string json = File.ReadAllText(levelDataPath);
        levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        SaveLevel();
    }
    #endregion
}
