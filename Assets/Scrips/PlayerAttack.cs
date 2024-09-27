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

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Update is private called once private per frame

    private void Update()

    {
        grounded = player.GetComponent<PlayerMovement>().CheckIfGrounded();
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetBool("IsAttacking", true);
            attacking = true;
            //attackArea.SetActive(true);

            //Attack();
        }

        if (attacking && grounded)
        {
            timer += Time.deltaTime;
            print(timer);
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

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (attacking && other.CompareTag("Enemy"))
    //    {
    //        other.GetComponent<Rigidbody2D>().velocity = new(20, 0);
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    //}
}