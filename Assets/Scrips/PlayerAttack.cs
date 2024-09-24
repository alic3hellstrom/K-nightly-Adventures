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

    private Animator anim;

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
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
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

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
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
