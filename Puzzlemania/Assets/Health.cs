using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;

    private float MAX_HEALTH = 100;
    

    public void Damage(float amount)
    {
        if(amount < 0)
        {
            Debug.Log("Cannot have negative damage");
        }
        
        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            Debug.Log("Cannot have negative healing");
        }

        bool wouldBeOverMax = health + amount > MAX_HEALTH;

        if(wouldBeOverMax)
        {
            health = MAX_HEALTH;
        } else
        {
            this.health += amount;
        }

        
    }

    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject);
    }
}
