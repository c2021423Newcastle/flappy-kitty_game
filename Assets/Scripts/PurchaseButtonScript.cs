using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButtonScript : MonoBehaviour
{
    private Character currentChar;
    private CharacterMenuScript charScript;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject coinIcon;

    void Start()
    {
        charScript = GameObject.Find("Character Model").GetComponent<CharacterMenuScript>();
        currentChar = charScript.GetCharList()[charScript.GetCharIdx()];
        SetText();
    }

    public void Purchase()
    {
        int coins = PlayerPrefs.GetInt("coins", 0);

        if (currentChar.GetOwned() == 0 && coins >= currentChar.GetPrice())
        {
            currentChar.SetOwned(1);
            PlayerPrefs.SetInt(currentChar.GetText(), 1);
            PlayerPrefs.SetInt("coins", coins - currentChar.GetPrice());
            PlayerPrefs.SetInt("selectedChar", charScript.GetCharIdx());
            SetText();
        }
    }

    public void SetText()
    {
        currentChar = charScript.GetCharList()[charScript.GetCharIdx()];
        if (currentChar.GetOwned() == 1)
        {
            text.GetComponent<Text>().text = "OWNED";
            coinIcon.SetActive(false);
        } else
        {
            text.GetComponent<Text>().text = currentChar.GetPrice().ToString();
            coinIcon.SetActive(true);
        }
    }
}
