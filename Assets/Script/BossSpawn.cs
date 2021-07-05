using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject attack;

    public float respawnTime = 1.0f;

    public float spawnArea = 100f;

    void Start()
    {
        StartCoroutine(attackWave());
    }

    private void spawnAttack()
    {
        GameObject a = Instantiate(attack) as GameObject;
        Vector3 me = transform.position;
        Vector3 spawn =
            new Vector3(me.x - 20,
                Random.Range(0, spawnArea),
                Random.Range(me.z - spawnArea, me.z + spawnArea));
        a.transform.position = spawn;
        // Debug.Log("Something Spawned");
    }

    IEnumerator attackWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
