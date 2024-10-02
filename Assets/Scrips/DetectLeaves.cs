using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectLeaves : MonoBehaviour
{
    [SerializeField] private GameObject leavesGen;

    private ParticleSystem[] generators;

    private void Start()
    {
        leavesGen.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //print(other.GetComponent<PlayerMovement>().horizontalValue);
            if (other.GetComponent<PlayerMovement>().horizontalValue != 0 && other.CompareTag("Player"))
            {
                leavesGen.SetActive(true);
            }
            else
            {
                leavesGen.SetActive(false);
            }
            leavesGen.transform.position = new(other.transform.position.x, leavesGen.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leavesGen.SetActive(false);
    }
}