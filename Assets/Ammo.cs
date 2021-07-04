using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int maxAmmo;
    public int remainingAmmo;
    public bool isFiring;
    public Text ammoDisplay;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        if (isFiring && remainingAmmo > 0)
        {
            --remainingAmmo;
            ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
        }

        if (Input.GetMouseButtonDown(1) && !isFiring)
        {
            ammoDisplay.text = "Reloading...";
            ReloadAmmo();
            ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
        }
    }

    public void ReloadAmmo()
    {
        remainingAmmo = maxAmmo;
    }

}