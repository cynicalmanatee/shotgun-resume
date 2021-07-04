using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{

    public GameObject[]  PrefabtoSpawn;

    public float spawnInterval = 2f;

    public float spawnTime;

    public bool isSpawn;
    // Start is called before the first frame update
    public void Start()
    {
        spawnTime = spawnInterval;
    }


    public void spawn()
    {
        spawnInterval -= Time.deltaTime;
        Debug.Log(spawnInterval);
        if (spawnInterval <= 0 && isSpawn)
        {
            int x = Random.Range(0,PrefabtoSpawn.Length-1);
            Instantiate(PrefabtoSpawn[x], transform.position, Quaternion.identity);
            spawnInterval = spawnTime;
        }
    }
    // Update is called once per frame
    public void Update()
    {
        spawn();
    }
}
