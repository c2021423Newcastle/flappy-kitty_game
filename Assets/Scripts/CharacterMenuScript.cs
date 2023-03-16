using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuScript : MonoBehaviour
{
    [SerializeField]
    private RuntimeAnimatorController bird;
    [SerializeField]
    private RuntimeAnimatorController cat;
    [SerializeField]
    private RuntimeAnimatorController dog;
    [SerializeField]
    private GameObject button;

    private List<Character> chars = new List<Character>();

    private int max;
    private int charIdx;

    void Awake()
    {   
        charIdx = PlayerPrefs.GetInt("selectedChar", 0);

        chars.Add(new Character("BIRD", bird, 0, 1));
        chars.Add(new Character("CAT", cat, 10, PlayerPrefs.GetInt("CAT", 0)));
        chars.Add(new Character("DOG", dog, 20, PlayerPrefs.GetInt("DOG", 0)));
        
        max = chars.Count;

        SetSkin();
    }

    public void Cycle(int dir)
    {
        charIdx += dir;

        if (charIdx < 0)
        {
            charIdx = 0;
        } else if (charIdx == max) 
        {
            charIdx = max - 1;
        } else 
        {
            SetSkin();
            button.GetComponent<PurchaseButtonScript>().SetText();
        }
    }

    private void SetSkin()
    {   
        Character character = chars[charIdx];

        gameObject.GetComponent<Animator>().runtimeAnimatorController = character.GetAnimatorController();
        gameObject.GetComponentInChildren<Text>().text = character.GetText();

        if (character.GetOwned() == 1)
        {
            PlayerPrefs.SetInt("selectedChar", charIdx);
        }
    }

    public int GetCharIdx()
    {
        return charIdx;
    }

    public List<Character> GetCharList()
    {
        return chars;
    }
}
