using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLeaves : MonoBehaviour
{
    [SerializeField] private GameObject leavesGen;

    private void Start()
    {
        leavesGen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            leavesGen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            leavesGen.SetActive(false);
        }
    }
}