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

    public Vector3 reloadAnimation;
    Vector3 originalRotation;

    void Start()
    {
        originalRotation = transform.localEulerAngles;
        maxAmmo = 12;
        remainingAmmo = 12;
        ammoDisplay.text = remainingAmmo + "/" + maxAmmo;
    }

    void Update()
    {
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