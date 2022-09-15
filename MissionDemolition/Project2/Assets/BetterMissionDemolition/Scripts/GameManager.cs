using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> // Inheriting Singleton and specifying the type.
{
    private int currentScene = 0;
    private int mainScene = 1;

    public void ChangeScene()
    {
        if (currentScene == 0)
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        } else if (currentScene == 1 )
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        } else
        {
            currentScene = 0;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void ReloadMainScene()
    {
        currentScene = mainScene;
        SceneManager.LoadScene(currentScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

            if (sceneName == "GameOverScene")
                GameManager.Instance.ReloadMainScene();
        }
    }
}