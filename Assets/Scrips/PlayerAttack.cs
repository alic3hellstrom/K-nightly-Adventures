using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f; 
    private float timer = 0f;
    public float radius;

    private Animator anim;

    public LayerMask enemies;

    void Start()
    {
        attackArea = transform.GetChild(2).gameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetBool("IsAttacking", true);
            Attack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;
            //print(timer);
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
    private void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackArea.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy) 
        
        attacking = true;
        attackArea.SetActive(true);
    }

    public void endAttack()
    { 
        anim.SetBool("IsAttacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.transform.position, radius);
    }
}
