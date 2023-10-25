using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public float health;
    public int experienceDrop;
    
    public EnemyHealthBar enemyHealthBar;

    void Start()
    {
        health = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
        
        enemyHealthBar.SetHealth(health);
    }

    public void Death()
    {
        LevelSystem.instance.AddExperience(experienceDrop);
        Destroy(gameObject);
    }

    blablabla;


}
