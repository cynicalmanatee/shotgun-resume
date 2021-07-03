using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    // Score and money variables; will increase/decrease depending on game state
    public int score;
    public int money;

    // The current job
    public Jobs.Career currentJob;
    public Text displayJob;

    // Holds the amount of time that has elapsed since the game has started
    public float timer;
    public Text displayTimer;

    // Time limit for the game in seconds
    public float timeLimit;

    // Whether the game is paused or not
    public bool paused;

    void Start() {
        score = 0;
        money = 0;
        currentJob = Jobs.Career.None;
        timer = 0.0f;
        timeLimit = 50;
        paused = true;
    }

    void Update() {
        
        // Increment timer if not paused
        if (!paused) {
            timer += Time.deltaTime;
            displayTimer.text = getCurrentTime().ToString();
        }

        if (timer >= timeLimit) {
            // Something to do once the game reaches the time limit
        }
    }

    // Edits score by a set amount (positive or negative)
    public void changeScore(int val) {
        score += val;
    }

    // Edits money by a set amount (positive or negative)
    public void changeMoney(int val) {
        money += val;
    }

    // Increases money by a set amount depending on the input job
    public void changeMoney(Jobs.Career job) {
        changeMoney(Jobs.getMoney(job));
    }

    public int getMoney() {
        return money;
    }

    // Sets the current job to the input job
    public void setJob(Jobs.Career job) {
        currentJob = job;
    }

    // Returns the current timer value rounded to the nearest integer
    private float getCurrentTime() {
        return Mathf.Round(timeLimit - timer);
    }

}