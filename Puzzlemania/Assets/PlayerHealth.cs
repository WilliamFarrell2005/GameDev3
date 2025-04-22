using UnityEngine;
using UnityEngine.UI; 
public class PlayerHealth : MonoBehaviour
{
    private AudioSource Death_Effect;
    private AudioSource PlayerGetHit;
    public float maxHealth = 100;
    private float currentHealth;

    public Slider healthBar; 

    void Start()
    {
        currentHealth = maxHealth;
        Death_Effect = GetComponent<AudioSource>();
        PlayerGetHit = GetComponent<AudioSource>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        PlayerGetHit.Play();
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Player took damage! Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Death_Effect.Play();
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
