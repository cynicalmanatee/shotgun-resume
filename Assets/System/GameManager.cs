using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Score and money variables; will increase/decrease depending on game state
    public int score;
    public int money;
    public TMP_Text displayMoney;

    // Player stat parameters
    public float fireRate;
    public int shotCount;
    public float interviewChn;
    public int maxHealth;

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

    void Start()
    {
        // Initialize base game parameters
        score = 0;
        money = 500;
        displayMoney.text = "Money: " + money;
        timer = 0.0f;
        timeLimit = 50;
        paused = true;

        // Initialize base player parameters
        fireRate = 5.0f;
        shotCount = 1;
        interviewChn = 0.05f;
        maxHealth = 50;
        currentJob = Jobs.Career.None;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape is being pressed.");
            // Some sort of pause menu functionality here
        }

        // Increment timer if not paused
        if (!paused)
        {
            timer += Time.deltaTime;
            displayTimer.text = getCurrentTime().ToString();
        }

        if (timer >= timeLimit)
        {
            // Something to do once the game reaches the time limit
        }
    }

    // Edits score by a set amount (positive or negative)
    public void changeScore(int val)
    {
        score += val;
    }

    // Edits money by a set amount (positive or negative)
    public void changeMoney(int val)
    {
        money += val;
        displayMoney.text = "Money: " + money.ToString();
    }

    // Increases money by a set amount depending on the input job
    public void changeMoney(Jobs.Career job)
    {
        changeMoney(Jobs.getMoney(job));
    }

    public int getMoney()
    {
        return money;
    }

    // Sets the current job to the input job
    public void setJob(Jobs.Career job)
    {
        currentJob = job;
    }

    public void setFireRate(float val)
    {
        fireRate = val;
    }

    public void setShotCount(int val)
    {
        shotCount = val;
    }

    public void setInterviewChn(float val)
    {
        interviewChn = val;
    }

    public void setMaxHealth(int val)
    {
        maxHealth = val;
    }

    public Jobs.Career getJob()
    {
        return currentJob;
    }

    public float getFireRate()
    {
        return fireRate;
    }

    public int getShotCount()
    {
        return shotCount;
    }

    public float getInterviewChn()
    {
        return interviewChn;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    // Returns the current timer value rounded to the nearest integer
    private float getCurrentTime()
    {
        return Mathf.Round(timeLimit - timer);
    }

    public void debugStats()
    {
        Debug.Log("FireRate: " + fireRate + "\tShotCount: " + shotCount + "\tInterviewChn: " + interviewChn + "\tMaxHP: " + maxHealth);
    }
}