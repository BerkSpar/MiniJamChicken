using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int points;
    public GameObject foodItem;
    public static bool isPaused = false;
    public GameObject camera;
    public GameObject menu;
    public GameObject player;


    public void PlayGame ()
    {
        camera.GetComponent<Camera>().orthographicSize = 6.0f;
        menu.SetActive(false);
        player.GetComponent<PlayerController>().isRunning = true;
        
    }
    void PauseGame ()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
