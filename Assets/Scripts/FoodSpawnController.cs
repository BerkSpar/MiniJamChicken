using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color color;

    private void Start() {
        meshRenderer = this.GetComponent<MeshRenderer>();
        color = meshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other) { 
        meshRenderer.material.color = new Color(color.r, color.g, color.b, 0.5f);
    }

    private void OnTriggerExit(Collider other) { 
        meshRenderer.material.color = new Color(color.r, color.g, color.b, 1f);
    }
}
