using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    private string key;
    public GameController gameController;
    public GameObject itemText;
    public float minSpawnTime = 1f, maxSpawnTime = 5f;

    private void Start() {
        StartCoroutine(spawn());
    }

    private void OnTriggerEnter(Collider other) {
        if (gameController.foodItem == null) return;

        FoodItemController foodItemController = gameController.foodItem.GetComponent<FoodItemController>();

        if (foodItemController.key != key) return;

        gameController.points += 1;

        foodItemController.DestroyItem();

        itemText.GetComponent<TextMesh>().text = "";

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
    }
}
