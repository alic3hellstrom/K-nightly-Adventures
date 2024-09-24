using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    private SpriteRenderer rend;

    private void Start()
    {

        rend = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
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
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock"))
        {
            moveSpeed = -moveSpeed;
        }
    }
}
