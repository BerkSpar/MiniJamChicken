using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    private string key;
    private GameController gameController;
    public GameObject itemText;
    public float minSpawnTime = 3f, maxSpawnTime = 7f;
    public float dieTime = 15f;
    private bool canDie = false;

    private void Start() {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(spawn());
    }

    private void OnTriggerEnter(Collider other) {
        if (gameController.foodItem == null) return;

        FoodItemController foodItemController = gameController.foodItem.GetComponent<FoodItemController>();

        if (foodItemController.key != key) return;

        gameController.points += 1;

        foodItemController.DestroyItem();

        itemText.GetComponent<TextMesh>().text = "";
        canDie = false;

        StartCoroutine(spawn());
    }

    private void AskForFood() {
        string[] foodTypes = new string[]{"corn", "worm", "carrot"};

        key = foodTypes[Random.Range(0, 3)];
        itemText.GetComponent<TextMesh>().text = key;
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        AskForFood();
        
        canDie = true;
        yield return new WaitForSeconds(dieTime);
        if(canDie) Destroy(gameObject);
    }
}
