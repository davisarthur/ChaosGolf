using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    public Ball ball1;
    public Ball ball2;
    public Ball ball3;
    public Ball ball4;

    // Start is called before the first frame update
    void Start() {
        Ball[] ballList = {ball1, ball2, ball3, ball4};
        for (int i = 0; i < 4; i++) {
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            ballList[i].Shoot(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)));
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LoadNextScene();
        }
    }

    void LoadNextScene() {
        SceneManager.LoadScene("Hole1");
    }
}
