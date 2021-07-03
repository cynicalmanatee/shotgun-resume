using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

    public GameManager gameManager;

    public GameObject panel;
    public bool displayPanel;
    public UpgradeSect[] upgradeSections;

    // Upgrade list and costs; each position of the array will correspond to the level of a specific upgrade
    public int[] upgradeCost = new int[5]{100, 200, 300, 400, 500};
    public int[] upgrades = new int[4]{0,0,0,0};

    // Maybe move this logic elsewhere?
    public int fireRate;
    public float interviewChce;
    public int fireCount;
    public int maxHealth;

    void Start() {
        displayPanel = false;
        panel.SetActive(false);

        // Initialize base player parameters
        fireRate = 10;
        interviewChce = 0.05f;
        fireCount = 1;
        maxHealth = 50;

        updateUpgrades();
    }

    public bool ableToUpgrade(int money, int currentLevel) {
        return (currentLevel != 5 && money >= upgradeCost[currentLevel]);
    }

    // Increments a specific upgrade by a set amount
    public void addUpgrade(int position) {
        if (ableToUpgrade(gameManager.getMoney(), upgrades[position])) {
            gameManager.changeMoney(upgradeCost[upgrades[position]]);
            ++upgrades[position];
        }
    }

    public void updateUpgrades() {
        fireRate = 1 + upgrades[0];
        interviewChce = 0.05f + 0.05f * (float) upgrades[1];
        fireCount = 1 + upgrades[2];
        maxHealth = 50 + (10 * upgrades[3]);
    }

    public void toggleDisplay() {
        displayPanel = !displayPanel;
        panel.SetActive(displayPanel);
    }
}