using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {//Det här är ett test för att se om heal och skada fungerar.
        if (Input.GetKeyDown(KeyCode.G))
        {
           // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
         
        }
            this.health -= amount;

        if (health <= 0)
        {
            Die();
        }

    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }


        bool wouldBeMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
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
