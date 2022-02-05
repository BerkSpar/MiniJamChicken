using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    public string key;
    public GameController gameController;

    private void OnTriggerEnter(Collider other) {
        if (gameController.foodItem == null) return;

        FoodItemController foodItemController = gameController.foodItem.GetComponent<FoodItemController>();

        if (foodItemController.key != key) return;

        gameController.points += 1;

        foodItemController.DestroyItem();
    }
}
