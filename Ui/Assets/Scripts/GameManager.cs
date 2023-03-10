using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    private int score;
    public bool isGameActive;
    
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnPrefab());
        UpdateScore(0);
    }

    void Update()
    {
        
    }

    IEnumerator SpawnPrefab()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);  
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Gameover()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
