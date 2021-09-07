using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlock : MonoBehaviour {
    
    public float freq;

    void Update() {
        transform.eulerAngles = new Vector3(0, 0, freq * 360 * Time.time);
    }
}
