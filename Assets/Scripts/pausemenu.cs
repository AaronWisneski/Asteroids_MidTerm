using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public string pauseInputName;
    public static bool isPaused = false;
    public GameObject pauseMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        unPause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(pauseInputName))
        {
            if (!isPaused)
                Pause();
            else
                unPause();
        }
    }


    //the function to pause the game
    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    //the function to unpause the game
    public void unPause()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
}
