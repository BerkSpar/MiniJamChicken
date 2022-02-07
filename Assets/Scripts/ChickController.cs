using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    private string key = "";
    private GameController gameController;
    public float minSpawnTime = 3f, maxSpawnTime = 7f;
    public float dieTime = 15f;
    public float currentDieTime = 15f;
    public bool isDied = false;

    public GameObject corn;
    public GameObject worm;
    public GameObject carrot;
    public GameObject water;

    public InterfaceFoodController interfaceFoodController;

    private void Start() {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        SetIcon(key);
        StartCoroutine(spawn());
    }

    private void OnTriggerEnter(Collider other) {
        if (gameController.foodItem == null) return;

        FoodItemController foodItemController = gameController.foodItem.GetComponent<FoodItemController>();

        if (foodItemController.key != key) return;

        gameController.points += 1;
        gameController.SetIcon("");

        foodItemController.DestroyItem();

        currentDieTime = dieTime;
        key = "";
        SetIcon(key);

        StartCoroutine(spawn());
    }

    void Update() {
        interfaceFoodController.timer = (int)currentDieTime;
    }

    private void SetIcon(string key) {
        interfaceFoodController.SetIcon(key);

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
        
        currentDieTime = dieTime;
        while(currentDieTime > 0) {
            yield return new WaitForSeconds(1);
            currentDieTime -= 1;
        }

        isDied = true;
        interfaceFoodController.SetActive(false);
        gameObject.SetActive(false);
        gameController.SetHP();
    }
}
