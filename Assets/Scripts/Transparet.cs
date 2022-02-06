using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparet : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    private void Start() {
       
    }

    private void OnTriggerEnter(Collider other) { 
       meshRenderer.enabled=false;
    }

    private void OnTriggerExit(Collider other) { 
       meshRenderer.enabled=true;
    }

}
