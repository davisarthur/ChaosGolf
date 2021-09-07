using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.SetActive(false);
    }
}
