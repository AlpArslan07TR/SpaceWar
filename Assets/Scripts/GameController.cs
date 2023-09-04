using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject obstacle;
    public int spawnCount;
    public float spawnDelay;
    public float starSpawn;
    public float waveDelay;
    
    public Text score_text;    
    public Text Gameover_text;
    public Text Restart_text;
    public Text Quit_text;
    public int score;

    private bool gameOver;
    private bool Restart;


    private void Update()
    {
        if (Restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }



    IEnumerator SpawnValues()
    {
        while (true)
        {
            yield return new WaitForSeconds(starSpawn);
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(obstacle, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);
            if (gameOver == true)
            {
                Restart_text.text = "Press R for Restart";
                Quit_text.text = "Press Q for Quit";
                Restart = true;
                break;
            }
        }
        
    }

    public void UpdateScore()
    {
        score += 10;
        score_text.text = "Score: " + score;
    }

    public void GameOver()
    {
        Gameover_text.text = "Game Over";
        gameOver = true;
    }

    void Start()
    {
        Gameover_text.text = "";
        Restart_text.text = "";
        Quit_text.text = "";
        gameOver = false;
        Restart = false;

        StartCoroutine(SpawnValues());
    }

}
