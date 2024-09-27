using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackArea : MonoBehaviour

{
    [SerializeField] private GameObject player;

    [SerializeField] private int damage = 10;
    //private int damage = 10;

    private void OnTriggerStay2D(Collider2D other)
    {
        Console.Clear();

        //if (collider.GetComponent<Health>() != null)
        //{
        //    float xAxis = collider.transform.position.x - playerTrans.position.x;

        //    print(-xAxis + ", " + 0);
        //    collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(xAxis * 40, 0));
        //    Health health = collider.GetComponent<Health>();
        //    health.Damage(damage);
        //}
        //print(player.GetComponent<PlayerAttack>().attacking);
        //print("Tried attacking");
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

        print(other.name);
        print(other.tag);

        PlayerMovement pM = player.GetComponent<PlayerMovement>();
        Health hp = other.GetComponent<Health>();
        if (player.GetComponent<PlayerAttack>().attacking && other.CompareTag("Enemy") && pM.CheckIfGrounded())
        {
            print("Attacking Enemy" + other.name);

            if (other.transform.position.x > player.transform.position.x && pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage);
            }
            else if (other.transform.position.x < player.transform.position.x && !pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(-2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage);
            }
        }
    }
}