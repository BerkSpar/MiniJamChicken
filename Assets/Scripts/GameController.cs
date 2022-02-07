using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int points;
    public GameObject foodItem;
    public static bool isPaused = false;
    public GameObject camera;
    public GameObject menu;
    public GameObject player;
    public Text scoreText;

    public GameObject corn;
    public GameObject worm;
    public GameObject carrot;
    public GameObject water;
    public GameObject empty;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    public ChickController chick1;
    public ChickController chick2;
    public ChickController chick3;

    public void PlayGame ()
    {
        menu.SetActive(false);

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

    void FixedUpdate() {
        scoreText.text = "Score: " + points * 10;
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
    
    public void SetHP() {
        int life = 3;

        if (chick1.isDied) life -= 1;
        if (chick2.isDied) life -= 1;
        if (chick3.isDied) life -= 1;

        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);
        
        switch(life) {
            case 1: 
                hp1.SetActive(true);
                break;
            case 2: 
                hp2.SetActive(true);
                break;                                
            case 3: 
                hp3.SetActive(true);
                break;                
        }
    }

    public void SetIcon(string key) {
        worm.SetActive(false);
        carrot.SetActive(false);
        water.SetActive(false);
        corn.SetActive(false);
        empty.SetActive(true);

        switch(key) {
            case "corn": 
                corn.SetActive(true);
                break;
            case "worm": 
                worm.SetActive(true);
                break;
            case "carrot": 
                carrot.SetActive(true);
                break;                                
            case "water": 
                water.SetActive(true);
                break;                
        }
    }

}
