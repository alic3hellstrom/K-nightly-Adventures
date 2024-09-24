using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControll : MonoBehaviour
{
    public FlyingEye[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FlyingEye enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FlyingEye enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }

    //Hello World
}
