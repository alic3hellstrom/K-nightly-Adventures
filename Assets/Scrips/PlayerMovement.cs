using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] public TMP_Text enemiesKilled;
    
    [SerializeField] private AudioClip[] pickupSounds;
    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private AudioClip[] hurtSounds;
    [SerializeField] private AudioClip[] respawnSounds;
    [SerializeField] private AudioClip[] deaths;

    private Health playerHealth;
    private bool isGrounded;
    public bool lookingRight = true;
    private float rayDistance = 0.25f;
    public float horizontalValue;
    private Rigidbody2D rgbd;
    private SpriteRenderer rend;
    private Animator anim;
    private AudioSource audioSorce;
    public int enemyKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled.text = "" + enemyKilled;
        audioSorce = GetComponent<AudioSource>();
        rgbd = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");

       if(horizontalValue < 0)
        {
            FlipSprite(true);
            lookingRight = false;

        }

        if (horizontalValue > 0)
        {
            FlipSprite(false);
            lookingRight = true;
        }

        CheckIfGrounded();

        if(Input.GetButtonDown("Jump") && CheckIfGrounded() == true)
        {
            Jump();
        }

        anim.SetFloat("MoveSpeed", Mathf.Abs(rgbd.velocity.x));
        anim.SetFloat("VerticalSpeed", rgbd.velocity.y);
        anim.SetBool("IsGrounded", CheckIfGrounded());

        
    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.Damage(damageAmount);
        if(playerHealth.currentHealth <= 0)
        {  
            audioSorce.PlayOneShot(deaths[Random.Range(0, deaths.Length)], 0.5f);
            RespawnSound();
       
        }
    }

    void FixedUpdate()
    {
        rgbd.velocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rgbd.velocity.y);
    }

    private void FlipSprite(bool direction)
    {
        Vector3 rotation = transform.eulerAngles;
        if (direction)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

    private void Jump()
    {
        rgbd.AddForce(new Vector2(0, jumpForce));
        audioSorce.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)], 0.5f);
    }
    private bool CheckIfGrounded()
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
        if(collision.gameObject.layer.Equals(8)) // 8 st�r f�r layer 8 som �r enemies, om spelaren krockar med enemies, f�r den 10 i skada. 
        {
            TakeDamage(10);
            audioSorce.PlayOneShot(hurtSounds[Random.Range(0, hurtSounds.Length)], 0.5f);
        }
    }

    public void UpdateScore() 
    
    {
        enemyKilled++;
    }
    public void RespawnSound()
    {
       
        audioSorce.PlayOneShot(respawnSounds[Random.Range(0, respawnSounds.Length)], 1f);
    }


}
