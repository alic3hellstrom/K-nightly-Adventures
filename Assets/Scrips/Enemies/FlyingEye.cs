using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using UnityEditor.VersionControl;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] public bool chase = false;
    public Transform startingPoint;
    private SpriteRenderer rend;
    private GameObject player;

    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        Flip();
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    public void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}