using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItemController : MonoBehaviour
{
    private GameController gameController;
    public string key;

    private void Start() {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameController.foodItem = gameObject;
            gameObject.SetActive(false);
        }

    }

    public void DestroyItem() {
        Destroy(gameObject);
    }
}
