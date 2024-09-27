using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool DevMode = false;

    public int startingHealth = 20;
    public int currentHealth = 0;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {//Det h�r �r ett test f�r att se om heal och skada fungerar.
        if (DevMode)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Damage(10);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                Heal(10);
            }
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        this.currentHealth -= amount;
        if (currentHealth < startingHealth)
        {
            anim.SetTrigger("Attacked");
        }

        if (currentHealth <= 0)
        {
            Die();
            anim.SetTrigger("IsDead");
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeMaxHealth = currentHealth + amount > startingHealth;

        if (wouldBeMaxHealth)
        {
            this.currentHealth = startingHealth;
        }
        else
        {
            this.currentHealth += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject, 1f);
    }
}