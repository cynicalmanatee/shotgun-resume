using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Current health is: " + health.ToString());
    }
}