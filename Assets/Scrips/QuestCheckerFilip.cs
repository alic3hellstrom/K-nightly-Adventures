using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestCheckerFilip : MonoBehaviour
{
    [SerializeField] private GameObject enemyTextField;
    [SerializeField] private int nextLevel = 0, questAmount = 6;

    private int enemiesKilled;

    private QuestScore questScore;

    private void Update()
    {
        questScore = enemyTextField.GetComponent<QuestScore>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemiesKilled = questScore.enemyKilled;

        if (enemiesKilled >= 6)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}