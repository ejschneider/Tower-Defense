
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    
    public float health = 100;
    public int goldValue = 25;

    [Header("Static Setup Fields")]
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) { Die(); }
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }

    void Die()
    {
        GameObject effectInstance = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effectInstance, 5f);

        Destroy(gameObject);
        PlayerStats.Gold += goldValue;
    }


}
