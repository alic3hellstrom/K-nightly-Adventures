using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScore : MonoBehaviour
{
    [SerializeField] public TMP_Text enemiesKilled;

    private float timer = 0;

    public int enemyKilled = 0;

    // Start is called before the first frame update
    private void Start()
    {
        enemiesKilled.text = "" + enemyKilled;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void AnotherBitesTheDust()
    {
        if (timer <= 0.01)
            timer = 0.25f;
        enemyKilled++;
        enemiesKilled.text = "" + enemyKilled;
    }
}