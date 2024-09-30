using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private int damage = 10;

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement pM = player.GetComponent<PlayerMovement>();
        Health hp = other.GetComponent<Health>();
        if (player.GetComponent<PlayerAttack>().attacking && other.CompareTag("Enemy") && pM.CheckIfGrounded())
        {
            print("Attacking Enemy" + other.name);
            print("HELLO WORLD");

            if (other.transform.position.x > player.transform.position.x && pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
            else if (other.transform.position.x < player.transform.position.x && !pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(-2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
        }
    }
}