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
        menu.SetActive(false);
        // camera.GetComponent<Camera>().orthographicSize = 6.0f;
        StartCoroutine(AnimateCamera());
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

    public void Quit() {
        Application.Quit();
    }

    
    IEnumerator AnimateCamera()
    {
        while(camera.GetComponent<Camera>().orthographicSize < 6f){
            camera.GetComponent<Camera>().orthographicSize += 0.1f;
            yield return new WaitForSeconds(.05f);

            if (camera.GetComponent<Camera>().orthographicSize > 4.5f)
                player.GetComponent<PlayerController>().isRunning = true;
        }

    }

}
