using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDataScript : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.SetInt("coins", 100);
        PlayerPrefs.SetInt("DOG", 0);
        PlayerPrefs.SetInt("selectedChar", 0);
        PlayerPrefs.SetInt("difficulty", 1);
        PlayerPrefs.SetInt("highScore", 0);
        SceneManager.LoadScene(0);
    }
}
