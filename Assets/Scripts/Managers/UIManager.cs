using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text timer;
    public Text finalScore;
    public float gameTime;
    public GameObject pickUpReact;

    private int score = 0;
    private bool gameFinished = false;
    private float seconds;
    private float minutes;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished) return;
        UpdateTimer();
    }
    public void UpScore()
    {
        if (gameFinished) return;
        ++score;
        scoreText.text = "Score: " + score;
    }

    void UpdateTimer()
    {
        gameTime -= Time.deltaTime;
        minutes = Mathf.Floor(gameTime / 60);
        seconds = gameTime % 60;
        if (seconds > 59) seconds = 59;
        //timer.text = "Time: " + gameTime.ToString("F0");
        timer.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        if (gameTime <= 0.0f)
        {
            GameFinished();
        }
    }

    void GameFinished()
    {
        gameFinished = true;
        pickUpReact.GetComponent<PickUpReact>().gameFinished = true;
        timer.text = "Time: 00:00";
        finalScore.text = "Your final score is: " + score;
    }
}
