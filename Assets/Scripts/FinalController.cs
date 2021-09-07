using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalController : MonoBehaviour {
    public Text finalScore;

    // Start is called before the first frame update
    void Start() {
        finalScore.text = "Your time: " + (Mathf.Round(Data.getTotalTime() * 100) / 100).ToString();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LoadNextScene();
        }
    }

    void LoadNextScene() {
        Data.resetTotalTime();
        SceneManager.LoadScene("Hole1");
    }
}
