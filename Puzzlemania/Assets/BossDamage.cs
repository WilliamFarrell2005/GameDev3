using UnityEngine;
using UnityEngine.UI;

public class BossDamage : MonoBehaviour
{
    public Transform player;    
    public float attackRange = 2.0f;
    public int baseDamage = 10;
    public float attackCooldown = 1.5f;
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;

    private float lastAttackTime;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }
    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            int damageToDeal = CalculateDamage();
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToDeal);
                lastAttackTime = Time.time;
                Debug.Log("Boss dealt damage to player!");
            }
        }
    }

    int CalculateDamage()
    {
        if (currentHealth <= maxHealth / 2)
        {
            return baseDamage * 2; // Boss does double damage when it's below 50% hp
        }
        else
        {
            return baseDamage;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Boss took damage. Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss died!");
        Destroy(gameObject);
    }
}

