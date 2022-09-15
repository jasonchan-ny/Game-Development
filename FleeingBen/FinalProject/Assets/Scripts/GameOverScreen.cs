using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public string nextSceneToLoad;
    public float timeLength = 10f; //seconds
    private float elapsedTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Menu");

        elapsedTime += Time.deltaTime;
        if (elapsedTime > timeLength)
            SceneManager.LoadScene("Menu");
    }
} 

