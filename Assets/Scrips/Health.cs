using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private bool DevMode = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform spawnPosition;

    private Rigidbody2D rgbd;

    public int startingHealth = 20;
    public int currentHealth = 20;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = spawnPosition.position;
        currentHealth = startingHealth;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()

    {
        healthBar.value = currentHealth;

        //Det h�r �r ett test f�r att se om heal och skada fungerar.
        if (DevMode)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Damage(10, false);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Damage(10, true);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                Heal(10);
            }
        }
    }

    public void Damage(int amount, bool isPlayer)
    {
        print("Damage Taken: " + amount);
        this.currentHealth -= amount;
        if (currentHealth < startingHealth)
        {
            anim.SetTrigger("Attacked");
        }
        print("TAking Damage");

        if (currentHealth <= 0)
        {
            Die(isPlayer);
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

        anim.SetTrigger("IsIdle");
    }

    public void Respawn()
    {
        transform.position = spawnPosition.position;
        rgbd.velocity = Vector2.zero;
    }

    private void Die(bool isPlayer)
    {
        Debug.Log("I am Dead");
        if (!isPlayer)
        {
            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }
    }
}