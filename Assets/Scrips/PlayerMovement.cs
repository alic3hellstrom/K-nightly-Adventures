using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform spawnPosition;
    //[SerializeField] private Health playerHealth;

    public float hitTimer = 0;

    private Health playerHealh;

    public bool lookingRight = true;

    private bool isGrounded;
    private float rayDistance = 0.25f;
    private float horizontalValue;
    private Rigidbody2D rgbd;
    private SpriteRenderer rend;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerHealh = this.GetComponent<Health>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");

        if (horizontalValue < 0)
        {
            FlipSprite(true);
            lookingRight = false;
        }

        if (horizontalValue > 0)
        {
            FlipSprite(false);
            lookingRight = true;
        }

        if (Input.GetButtonDown("Jump") && CheckIfGrounded() == true)
        {
            Jump();
        }

        anim.SetFloat("MoveSpeed", Mathf.Abs(rgbd.velocity.x));
        anim.SetFloat("VerticalSpeed", rgbd.velocity.y);
        anim.SetBool("IsGrounded", CheckIfGrounded());

        if (hitTimer > 0)
        {
            //print(hitTimer);
            hitTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealh.Damage(damageAmount, true);
        if (playerHealh.currentHealth <= 0)
        {
            Respawn();
            playerHealh.Heal(playerHealh.startingHealth);
        }
    }

    private void FixedUpdate()
    {
        rgbd.velocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rgbd.velocity.y);
    }

    private void FlipSprite(bool direction)
    {
        rend.flipX = direction;
    }

    private void Jump()
    {
        rgbd.AddForce(new Vector2(0, jumpForce));
    }

    public bool CheckIfGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftFoot.position, Vector2.down, rayDistance, whatIsGround);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, Vector2.down, rayDistance, whatIsGround);

        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || rightHit.collider != null && rightHit.collider.CompareTag("Ground"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(8)) // 8 st�r f�r layer 8 som �r enemies, om spelaren krockar med enemies, f�r den 10 i skada.
        {
            TakeDamage(10);
        }
    }

    public void Respawn()
    {
        transform.position = spawnPosition.position;
        rgbd.velocity = Vector2.zero;
    }
}