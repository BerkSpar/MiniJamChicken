using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnController : MonoBehaviour
{
    public GameObject foodItem;
    public float waitTime = 2f;
    public float opacity = 0.2f;
    private bool canSpawn = false;

    private MeshRenderer[] meshRenderers;

    private void Start() {
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other) { 
        if (other.tag == "Player") {
            foreach(MeshRenderer meshRenderer in meshRenderers) {
                foreach(Material material in meshRenderer.materials)
                    material.color = new Color(material.color.r, material.color.g, material.color.b, opacity);
            }

            StartCoroutine(spawn());
        }
    }

    private void OnTriggerExit(Collider other) { 
        foreach(MeshRenderer meshRenderer in meshRenderers) {
            foreach(Material material in meshRenderer.materials)
                material.color = new Color(material.color.r, material.color.g, material.color.b, 1f);
        }

        canSpawn = false;
    }

    IEnumerator spawn()
    {
        canSpawn = true;
        yield return new WaitForSeconds(waitTime);

        float x = Random.Range(-2, 2);
        float z = Random.Range(-3, 3);

        Vector3 location = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (canSpawn) Instantiate(foodItem, location, Quaternion.identity);
    }
}

