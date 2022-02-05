using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnController : MonoBehaviour
{
    public GameObject foodItem;
    public float waitTime = 2f;
    private bool canSpawn = false;

    private MeshRenderer meshRenderer;
    private Color color;

    private void Start() {
        meshRenderer = this.GetComponent<MeshRenderer>();
        color = meshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other) { 
        meshRenderer.material.color = new Color(color.r, color.g, color.b, 0.5f);

        StartCoroutine(spawn());
    }

    private void OnTriggerExit(Collider other) { 
        meshRenderer.material.color = new Color(color.r, color.g, color.b, 1f);

        canSpawn = false;
    }

    IEnumerator spawn()
    {
        canSpawn = true;
        yield return new WaitForSeconds(waitTime);

        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);

        Vector3 location = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (canSpawn) Instantiate(foodItem, location, Quaternion.identity);
    }
}

