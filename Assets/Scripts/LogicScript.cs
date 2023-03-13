using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int highScore;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Point);

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
