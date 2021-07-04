using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{

    public GameObject[]  PrefabtoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }


    void spawn()
    {
        int x = Random.Range(0,PrefabtoSpawn.Length-1);
        Instantiate(PrefabtoSpawn[x], transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
