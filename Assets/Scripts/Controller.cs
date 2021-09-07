using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Ball ballPrefab;
    public float waitTime;
    public Transform arrowSystemT;
    public Text totalTime;
    public Text holeTime;
    public Text holeNumText;
    public string nextHole;
    public int holeNum;
    
    Vector3 spawnPoint;
    Ball ball;
    bool ballReady;

    bool first = true;
    bool stopped;
    float start;
    float stop;

    // Start is called before the first frame update
    void Start() {
        spawnPoint = arrowSystemT.position;
        ball = Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
        ballReady = true;
        totalTime.text = (Mathf.Round(Data.getTotalTime() * 100.0f) / 100.0f).ToString();
        holeNumText.text = "Hole " + holeNum.ToString();
    }

    // Update is called once per frame
    void Update() {
        Camera cam = Camera.main;
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y, ball.transform.position.z));
        Vector3 arrowDir = ball.transform.position - mousePosition;
        float arrAngle = Mathf.Atan2(arrowDir.y, arrowDir.x) * Mathf.Rad2Deg + 180;
        arrowSystemT.eulerAngles = new Vector3(arrowSystemT.eulerAngles.x, arrowSystemT.eulerAngles.y, arrAngle);
        
        if (Input.GetMouseButtonDown(0) && ballReady) {
            if (first) {
                start = Time.time;
                first = false;
            }
            ball.Shoot(arrowDir.normalized);
            ballReady = false;
            arrowSystemT.gameObject.SetActive(false);
            StartCoroutine(RespawnBall());
        }

        if (first) {
            holeTime.text = "0.00";
        }
        else if (!stopped) {
            holeTime.text = (Mathf.Round((Time.time - start) * 100) / 100).ToString();
        }
        else {
            holeTime.text = (Mathf.Round((stop - start) * 100) / 100).ToString();
        }
        
    }

    IEnumerator RespawnBall() {
        yield return new WaitForSeconds(waitTime);
        ball = Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
        ballReady = true;
        arrowSystemT.gameObject.SetActive(true);
    }

    public void StopTimer() {
        if (!stopped) {
            stop = Time.time;
            Data.addToTotal(stop - start);
            totalTime.text = (Mathf.Round(Data.getTotalTime() * 100.0f) / 100.0f).ToString();
            StartCoroutine(LoadNextScene());
        }
        stopped = true;
    }

    IEnumerator LoadNextScene() {
        yield return new WaitForSeconds(1);
        if (nextHole != "") {
            SceneManager.LoadScene(nextHole);
        }
    }

}
