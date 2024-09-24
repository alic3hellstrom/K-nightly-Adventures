using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackArea : MonoBehaviour

{
    [SerializeField] private Transform playerTrans;

    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            float xAxis = collider.transform.position.x - playerTrans.position.x;

            print(-xAxis + ", " + 0);
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(xAxis * 40, 0));
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}