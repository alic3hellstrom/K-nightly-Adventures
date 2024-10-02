using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private bool DevMode = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject enemyTextField;
    private QuestScore qS;

    private Rigidbody2D rgbd;
    public int startingHealth = 20;
    public int currentHealth = 0;
    private Animator anim;
    private GameObject player;

    private float timer = 0;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = startingHealth;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        qS = enemyTextField.GetComponent<QuestScore>();
    }

    private void Update()

    {
        healthBar.value = currentHealth;
        //Det h�r �r ett test f�r att se om heal och skada fungerar.
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
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Damage(int amount)
    {
        if (timer <= 0.01)
        {
            timer = 0.25f;
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
            }
            this.currentHealth -= amount;
            if (currentHealth > 0)
            {
                anim.SetTrigger("Attacked");
            }
            else
            {
                anim.SetTrigger("IsDead");
                qS.AnotherBitesTheDust();
                Die();
            }
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
        currentHealth = startingHealth;

        anim.SetTrigger("IsAlive");
    }

    private void Die()
    {
        bool isPlayer = this.CompareTag("Player");
        Debug.Log("I am Dead");
        if (!isPlayer)
        {
            Destroy(gameObject, 1f);
            //this.GetComponent<PlayerMovement>();
        }
        else
        {
            Invoke("Respawn", 1f);
        }
    }
}