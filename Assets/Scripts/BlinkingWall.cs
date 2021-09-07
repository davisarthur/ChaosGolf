using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingWall : MonoBehaviour {
    
    public GameObject wall;
    public float freq;
    public float offset;
    public float threshold;

    bool active;

    void Update() {
        if (Mathf.Cos(freq * (2 * Mathf.PI) * Time.time + offset) > threshold) {
            active = true;
        }
        else {
            active = false;
        }
        if (active) {
            wall.gameObject.SetActive(true);
        }
        else {
            wall.gameObject.SetActive(false);
        }
        Debug.Log(Time.timeScale);
    }
}
