using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public float bossPercent = 0.5f;

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
        if (Random.Range(0f, 100f) <= bossPercent)
        {
            SceneManager
                .LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Destroy (gameObject);
    }
}
