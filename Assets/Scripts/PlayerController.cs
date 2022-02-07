using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 0.5f;
    public bool isRunning = false;

    public Animator animator;

    void FixedUpdate () {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        
        GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0f,angle*-1,0f)));

        if (isRunning) {
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1,0,0)*speed,ForceMode.Force);
        }
        animator.SetBool("Running", isRunning);


    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
