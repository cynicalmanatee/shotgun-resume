using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int maxAmmo = 12;
    public int remainingAmmo = 12;
    public float printTime;
    public float donePrint;
    public bool reloading;
    public Text ammoDisplay;

    public Vector3 reloadAnimation;
    Vector3 originalRotation;

    void Start()
    {
        originalRotation = transform.localEulerAngles;
        maxAmmo = 12;
        remainingAmmo = 12;
        printTime = 2.0f;
        reloading = false;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

    void Update()
    {
        if (reloading && Time.time > donePrint) {
            remainingAmmo = maxAmmo;
            ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
            reloading = false;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            StartReload();
        } else if (Input.GetButtonUp("Fire2")) {
            StopReload();
        }
    }

    private void StartReload()
    {
        transform.localEulerAngles += reloadAnimation;
    }

    private void StopReload()
    {
        transform.localEulerAngles = originalRotation;
    }

    public void ReloadAmmo()
    {
        ammoDisplay.text = "Printing...";
        reloading = true;
        donePrint = Time.time + printTime;
    }

    public void ShootAmmo()
    {
        --remainingAmmo;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

}