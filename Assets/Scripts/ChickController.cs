using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    private string key = "";
    private GameController gameController;
    public float minSpawnTime = 3f, maxSpawnTime = 7f;
    public float dieTime = 15f;
    private bool canDie = false;
    public bool isDied = false;

    public GameObject corn;
    public GameObject worm;
    public GameObject carrot;
    public GameObject water;


    private void Start() {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(spawn());
        SetIcon(key);
    }

    private void OnTriggerEnter(Collider other) {
        if (gameController.foodItem == null) return;

        FoodItemController foodItemController = gameController.foodItem.GetComponent<FoodItemController>();

        if (foodItemController.key != key) return;

        gameController.points += 1;
        gameController.SetIcon("");

        foodItemController.DestroyItem();

        canDie = false;
        key = "";
        SetIcon(key);

        StartCoroutine(spawn());
    }

    private void SetIcon(string key) {
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

    private void AskForFood() {
        string[] foodTypes = new string[]{"corn", "worm", "carrot", "water"};

        key = foodTypes[Random.Range(0, 4)];

        SetIcon(key);
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        AskForFood();
        
        canDie = true;
        yield return new WaitForSeconds(dieTime);

        if(canDie) {
            isDied = true;
            gameObject.SetActive(false);
            gameController.SetHP();
        }
    }
}
