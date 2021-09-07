using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    Controller controller;
    public float speed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        controller = GameObject.Find("Background").GetComponent<Controller>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector3 dir) {
        rb.velocity = speed * new Vector3(dir.x, dir.y, 0).normalized;
        gameObject.layer = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Finish") {
            controller.StopTimer();
            rb.Sleep();
            transform.position = other.transform.position + Vector3.back;
            Debug.Log("Holed");
        }
    }
}
