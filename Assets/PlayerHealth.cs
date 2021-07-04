using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    GameManager gameManager;

    void Start() {
        health = gameManager.getMaxHealth();
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Current health is: " + health.ToString());
    }
}