using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItemController : MonoBehaviour
{
    public GameController gameController;
    public string key;

    private void OnTriggerEnter(Collider other) {
        gameController.foodItem = gameObject;
        gameObject.SetActive(false);
    }

    public void DestroyItem() {
        Destroy(gameObject);
    }
}
