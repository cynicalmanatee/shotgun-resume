using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int maxAmmo = 12;
    public int remainingAmmo = 12;
    public bool isFiring;
    public Text ammoDisplay;

    void Start()
    {
        maxAmmo = 12;
        remainingAmmo = 12;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     isFiring = true;
        // }
        // else
        // {
        //     isFiring = false;
        // }

        // if (isFiring && remainingAmmo > 0)
        // {
        //     ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
        // }

        // if (Input.GetMouseButtonDown(1) && !isFiring)
        // {
        //     ammoDisplay.text = "Reloading...";
        //     ReloadAmmo();
        //     ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
        // }
    }

    public void ReloadAmmo()
    {
        ammoDisplay.text = "Reloading...";
        remainingAmmo = maxAmmo;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

    public void ShootAmmo()
    {
        --remainingAmmo;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

}