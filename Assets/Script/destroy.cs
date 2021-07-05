using UnityEngine;
using UnityEngine.SceneManagement;

public class destroy : MonoBehaviour
{
    public float speed = 20.0f;

    private Rigidbody rb;

    private Transform player;

    public float health = 1f;

    public GameObject Boss;

    void start()
    {
        player = GameObject.Find("First Person Player").transform;
        rb = this.GetComponent<Rigidbody>();
        Vector3 direction = player.position - this.transform.position;
        float factor =
            (direction.magnitude * direction.magnitude) / (speed * speed);
        direction = direction / factor;
        rb.velocity = direction;
    }

    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        transform
            .rotation
            .SetFromToRotation(transform.position, player.position);
        rb.velocity = (direction * (speed)) / (direction.magnitude);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Boss.GetComponent<BossSpawn>().loseHealth();
        Destroy (gameObject);
    }
}
