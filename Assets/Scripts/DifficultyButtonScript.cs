using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonScript : MonoBehaviour
{   
    private int difficulty;
    
    [SerializeField]
    private Text text;

    private string prefix = "DIFFICULTY:\n";

    // Start is called before the first frame update
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty", 1);

        SetDifficultyText();
    }

    private void SetDifficultyText() {
        switch (difficulty)
        {
            case 1:
                text.text = prefix + "EASY";
                break;
            case 2:
                text.text = prefix + "MEDIUM";
                break;
            case 3:
                text.text = prefix + "HARD";
                break;
        }
    }

    public void CycleDifficulty () {
        difficulty++;

        if (difficulty > 3) {
            difficulty = 1;
        }

        PlayerPrefs.SetInt("difficulty", difficulty);

        SetDifficultyText();
    }
}
