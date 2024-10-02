using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 6;
    [SerializeField] private int levelToLoad;

    private Animator anim;
    private bool levelIsLoading = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerMovement>().enemyKilled >= questGoal)
            {
                dialogueBox.SetActive(true);
                finishedText.SetActive(true);
                anim.SetTrigger("Box");
                Invoke("LoadNextLevel", 2.0f);
                levelIsLoading = true;
            }
            else
            {
                dialogueBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
        }
    }


    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelIsLoading)
        {
            dialogueBox.SetActive(false);
            finishedText.SetActive(false);
            unfinishedText.SetActive(false);

        }
    }
}
