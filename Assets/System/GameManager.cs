using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text displayMoney;

    // The current job
    public TMP_Text displayJob;

    // Holds the amount of time that has elapsed since the game has started
    public float timer;
    public TMP_Text displayTimer;

    // Time limit for the game in seconds
    public float timeLimit;
    public bool runTimer;

    // Whether the game is paused or not
    public bool paused;
    public GameObject pauseScreen;

    public GameObject hud;

    void Start()
    {
        // Initialize base game parameters
        PlayerStats.score = 0;
        PlayerStats.money = 1500;
        displayMoney.text = "Money: " + PlayerStats.money;
        displayJob.text = "Job: " + PlayerStats.currentJob;
        timer = 0.0f;
        timeLimit = 50;
        runTimer = true;
        paused = false;
        pauseScreen.SetActive(false);

        // Initialize base player parameters
        PlayerStats.fireRate = 3.0f;
        PlayerStats.shotCount = 1;
        PlayerStats.interviewChn = 0.05f;
        PlayerStats.maxHealth = 50;
        PlayerStats.currentJob = Jobs.Career.None;
    }
    
    void Update()
    {
        displayMoney.text = "Money: " + PlayerStats.money.ToString();

        if (Input.GetButtonDown("Cancel"))
        {
            togglePaused();
        }

        // Increment timer if not paused
        if (runTimer)
        {
            timer += Time.deltaTime;
            displayTimer.text = getCurrentTime().ToString();
        }

        if (timer >= timeLimit)
        {
            // Something to do once the game reaches the time limit
        }

    }

    // Returns the current timer value rounded to the nearest integer
    public float getCurrentTime()
    {
        return Mathf.Round(timeLimit - timer);
    }

    public void debugStats()
    {
        Debug.Log("FireRate: " + PlayerStats.fireRate + "\tShotCount: " + PlayerStats.shotCount + "\tInterviewChn: " + PlayerStats.interviewChn + "\tMaxHP: " + PlayerStats.maxHealth);
    }

    public void togglePaused() {
        runTimer = !runTimer;
        if (!paused) {
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            hud.SetActive(true);
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        paused = !paused;
    }


    public void toggleHud() {
        hud.SetActive(!paused);
    }

    public void quitGame() {
        Application.Quit();
    }
}