using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private string text;
    private RuntimeAnimatorController animatorController;
    private int price;
    private int owned;

    public Character(string text, RuntimeAnimatorController animatorController, int price, int owned) 
    {
        this.text = text;
        this.animatorController = animatorController;
        this.price = price;
        this.owned = owned;
    }
    
    public int GetPrice()
    {
        return price;
    }
    
    public int GetOwned()
    {
        return owned;
    }

    public void SetOwned(int val)
    {
        owned = val;
    }
    
    public RuntimeAnimatorController GetAnimatorController()
    {
        return animatorController;
    }
    
    public string GetText()
    {
        return text;
    }
}
