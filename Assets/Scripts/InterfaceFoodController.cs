using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceFoodController : MonoBehaviour
{
    public GameObject corn;
    public GameObject worm;
    public GameObject carrot;
    public GameObject water;

    public Text timerText;

    public int timer;

    public void SetActive(bool active)
    {   
        gameObject.SetActive(active);
    }

    void Update()
    {
        timerText.text = timer + "s";

        if(timer < 10) {
            timerText.color = Color.red;
        } else {
            timerText.color = Color.black;
        }
    }

    public void SetIcon(string key) {
        worm.SetActive(false);
        carrot.SetActive(false);
        water.SetActive(false);
        corn.SetActive(false);

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
