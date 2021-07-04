using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject panel;
    public bool displayPanel;

    // Upgrade list and costs; each position of the array will correspond to the level of a specific upgrade
    public int[] upgradeCost = new int[5] { 100, 200, 300, 400, 500 };
    public int[] upgrades = new int[4] { 0, 0, 0, 0 };
    public int[] maxLevels = new int[4] { 5, 5, 5, 5 };
    public TMP_Text[] currentLevels = new TMP_Text[4];
    public Button[] upgradeButtons = new Button[4];

    void Start()
    {
        displayPanel = false;
        panel.SetActive(false);
        updateUpgrades();

        //Code derived from: https://answers.unity.com/questions/1376530/add-listeners-to-array-of-buttons.html
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            upgradeButtons[closureIndex].onClick.AddListener(() => addUpgrade(closureIndex));
        }
    }

    public bool ableToUpgrade(int money, int index)
    {
        return (upgrades[index] < maxLevels[index] && money >= upgradeCost[upgrades[index]]);
    }

    // Increments a specific upgrade by a set amount
    public void addUpgrade(int position)
    {
        if (ableToUpgrade(PlayerStats.money, position))
        {
            PlayerStats.changeMoney(-1 * upgradeCost[upgrades[position]]);
            ++upgrades[position];
            updateUpgrades();
        }
    }

    public void updateUpgrades()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            currentLevels[i].text = upgrades[i] + "/" + maxLevels[i];
        }

        PlayerStats.fireRate = 2.0f - ((float)upgrades[0] * 0.2f);
        PlayerStats.shotCount = 1 + upgrades[1];
        PlayerStats.interviewChn = 0.05f + 0.05f * (float)upgrades[2];
        PlayerStats.maxHealth = 50 + (10 * upgrades[3]);

        gameManager.debugStats();
    }

    public void toggleDisplay()
    {
        displayPanel = !displayPanel;
        panel.SetActive(displayPanel);
    }
}