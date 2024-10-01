using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float bounciness = 100;
    private SpriteRenderer rend;
    private Rigidbody2D rgbd;
    private Animator anim;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);

        if (moveSpeed > 0)
        {
            rend.flipX = true;
        }

        if (moveSpeed < 0)
        {
            rend.flipX = false;
        }

        anim.SetFloat("MoveSpeed", Mathf.Abs(rgbd.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock"))
        {
            moveSpeed = -moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("IsDead");
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            Destroy(gameObject, 0.5f);
        }
    }
}