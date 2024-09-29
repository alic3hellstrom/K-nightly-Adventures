using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class HealthBar: MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Health playerHealth;



    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        SetHealth(playerHealth.startingHealth);
    }


    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}    