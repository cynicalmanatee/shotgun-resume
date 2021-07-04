using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 20.0f;

    private Rigidbody rb;

    private Transform player;

    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("First Person Player").transform;
        rb = this.GetComponent<Rigidbody>();
        Vector3 direction = player.position - this.transform.position;
        float factor =
            (direction.magnitude * direction.magnitude) / (speed * speed);
        direction = direction / factor;
        rb.velocity = direction;
    }

    void OnMouseDown()
    {
        health--;
        if (health < 1)
        {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        rb.velocity = (direction * (speed)) / (direction.magnitude);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("destroyed");
        Destroy(gameObject);
    }
}
