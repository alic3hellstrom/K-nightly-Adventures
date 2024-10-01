using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private int damage = 1;

    [SerializeField] private float knockBack = .5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Console.Clear();

        //if (player.GetComponent<PlayerAttack>().attacking == true)
        //{
        //    print("Detected attacking");
        //}
        //if (other.CompareTag("Enemy"))
        //{
        //    print("Detected enemy as enemy");
        //    print("Their name = " + other.name);
        //    print(other.name);
        //}

        PlayerMovement pM = player.GetComponent<PlayerMovement>();
        Health hp = other.GetComponent<Health>();
        //print("Check if grounded:");
        //print(pM.CheckIfGrounded());

        GameObject otherGO = other.gameObject;

        if (player.GetComponent<PlayerAttack>().attacking && other.CompareTag("Enemy") && pM.CheckIfGrounded() && pM.hitTimer <= 0.01f)
        {
            print("Attacking Enemy" + other.name);
            //print("HELLO WORLD");
            pM.hitTimer = 0.25f;
            if (otherGO.transform.position.x > player.transform.position.x && pM.lookingRight)
            {
                otherGO.GetComponent<Rigidbody2D>().AddForce(new(knockBack * 15, knockBack * 5), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
            else if (otherGO.transform.position.x < player.transform.position.x && !pM.lookingRight)
            {
                otherGO.GetComponent<Rigidbody2D>().AddForce(new(-knockBack * 15, knockBack * 5), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
        }
    }
}