using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWall : MonoBehaviour {

    public GameObject key;

    void Update() {
        if (key.gameObject.activeSelf) {
            return;
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
