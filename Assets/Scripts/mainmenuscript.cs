using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        Debug.Log("Start");
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        //Quit the game
        Application.Quit();
        Debug.Log("Exit");
    }
}
