using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    public HealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0) 
            Destroy(gameObject);
        
        healthBar.SetHealth(health);
    }
}

