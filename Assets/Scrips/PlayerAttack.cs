using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    [SerializeField] private GameObject player;

    public bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private bool grounded = true;

    private Animator anim;

    public LayerMask enemies;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //attackArea.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = player.GetComponent<PlayerMovement>().CheckIfGrounded();
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetBool("IsAttacking", true);
            attacking = true;
        }

        if (attacking && grounded)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(false);
            }
        }
    }

    public void endAttack()
    {
        anim.SetBool("IsAttacking", false);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    //}
}