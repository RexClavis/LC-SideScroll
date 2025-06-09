using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CheckSaveFile();
            levelCurrent = GameManager.Instance.levelCurrent;
            AddChangeSceneListeners();
            AddExitButtonListener();
            DisableLockedLevel();
        }
        else
        {
            Debug.LogWarning("GameManager.Instance is null! Make sure GameManager exists in the scene.");
        }
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;
    public int sceneIndex = 0;

    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() =>
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.ChangeScene(sceneIndex);
                }
                else
                {
                    Debug.LogWarning("GameManager.Instance is null! Cannot change scene.");
                }
            });
        }
    }

    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelCurrent)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    #endregion

    #region Exit Application
    [Header("Exit Button")]
    public Button exitButton;

    private void AddExitButtonListener()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitApplication);
        }
        else
        {
            Debug.LogWarning("Exit button is not assigned!");
        }
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
    #endregion
}