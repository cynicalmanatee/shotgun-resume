using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{

    public GameObject[]  PrefabtoSpawn;

    public AudioSource[] spawnSound;

    public float spawnInterval = 2.0f;
    public bool isSpawn;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(setSpawn());
    }
    IEnumerator setSpawn()
    {
        while (true)
        {
            if (isSpawn)
            {
                yield return new WaitForSeconds(spawnInterval);
                Debug.Log("spawn trigger");
                spawn();
            }
            else
            {
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    public void spawn()
    {

        int enemytype = Random.Range(0,PrefabtoSpawn.Length);
        int spawnsoundtype = Random.Range(0,spawnSound.Length);
        Instantiate(PrefabtoSpawn[enemytype], transform.position, Quaternion.identity);
        spawnSound[spawnsoundtype].Play();

    }
    // Update is called once per frame
    public void Update()
    {
    }
}
