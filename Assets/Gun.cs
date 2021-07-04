using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 2f;
    public float impactForce = 10f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float nextFire = 0.0f;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            if (Ammo.remainingAmmo >= 1) {
                nextFire = Time.time + fireRate;
                Shoot();
                --Ammo.remainingAmmo;
            } else {
                Debug.Log("No ammo!");
            }
        }
    }

    void Shoot ()
    {
        muzzleFlash.Play();
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

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 50f);
        }
    }
}

