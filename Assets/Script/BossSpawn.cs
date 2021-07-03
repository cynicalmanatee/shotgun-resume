using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject attack;

    public float respawnTime = 1.0f;

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
                Random.Range(0, 40f),
                Random.Range(me.z - 40f, me.z + 40f));
        a.transform.position = spawn;
        Debug.Log("Something Spawned");
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
