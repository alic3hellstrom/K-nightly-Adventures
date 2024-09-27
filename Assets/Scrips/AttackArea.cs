using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider)
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
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
