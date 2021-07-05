using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate;
    public float impactForce = 10f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float nextFire = 0.0f;

    public AudioSource bang;
    public Ammo ammo;
    public GameManager gameManager;

    // Update is called once per frame

    void Start()
    {
        fireRate = PlayerStats.fireRate;
    }

    void Update()
    {
        if (!gameManager.paused)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire && !ammo.reloading)
            {
                if (ammo.remainingAmmo >= 1)
                {
                    nextFire = Time.time + fireRate;
                    Shoot();
                }
                else
                {
                    Debug.Log("No ammo!");
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                Reload();
                Debug.Log("RELOADING...");
            }
        }

    }

    void Shoot()
    {
        muzzleFlash.Play();
        bang.Play();
        ammo.ShootAmmo();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Vector3 spread = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            Vector3 spread2 = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            Vector3 spread3 = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            Vector3 spread4 = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            Vector3 spread5 = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
            GameObject impactGO = Instantiate(impactEffect, hit.point + spread, Quaternion.LookRotation(hit.normal));
            GameObject impactGO2 = Instantiate(impactEffect, hit.point + spread2, Quaternion.LookRotation(hit.normal));
            GameObject impactGO3 = Instantiate(impactEffect, hit.point + spread3, Quaternion.LookRotation(hit.normal));
            GameObject impactGO4 = Instantiate(impactEffect, hit.point + spread4, Quaternion.LookRotation(hit.normal));
            GameObject impactGO5 = Instantiate(impactEffect, hit.point + spread5, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 50f);
            Destroy(impactGO2, 50f);
            Destroy(impactGO3, 50f);
            Destroy(impactGO4, 50f);
            Destroy(impactGO5, 50f);
        }
    }


    void Reload()
    {
        ammo.ReloadAmmo();
    }
}

