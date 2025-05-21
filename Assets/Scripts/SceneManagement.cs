using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GameScreen");
    }
}
