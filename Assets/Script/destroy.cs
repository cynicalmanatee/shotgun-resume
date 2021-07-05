using UnityEngine;
using UnityEngine.SceneManagement;

public class destroy : MonoBehaviour
{
    public float health = 50f;

    public GameObject Boss;

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
