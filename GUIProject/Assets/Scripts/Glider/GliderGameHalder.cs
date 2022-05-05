using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GliderGameHalder : MonoBehaviour
{
    public GliderPlayer player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        GliderObstuckales[] obstuckales = FindObjectsOfType<GliderObstuckales>();

        for (int i = 0; i < obstuckales.Length; i++) {
            Destroy(obstuckales[i].gameObject);
        }
    }

    public void GameOver()
    {   
        Debug.Log("Hit");
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Goal()
    {
                Debug.Log("Score");
        score++;
        scoreText.text = score.ToString();
    }

}