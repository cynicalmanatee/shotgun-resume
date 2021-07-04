using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumePaper : MonoBehaviour
{
    public float linger = 15f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(despawn());
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(linger);
        Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
