using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumePapar : MonoBehaviour
{
    public float duration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(duration);
        Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
