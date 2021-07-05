using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 originalRotation;
    public Ammo ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo.remainingAmmo >= 1) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AddRecoil();
            } else if (Input.GetButtonUp("Fire1")) {
                StopRecoil();
            }
        }
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }
}
