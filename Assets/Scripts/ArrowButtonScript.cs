using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonScript : MonoBehaviour
{
    private CharacterMenuScript charScript;

    // Start is called before the first frame update
    void Start()
    {
        charScript = GameObject.Find("Character Model").GetComponent<CharacterMenuScript>();
    }

    public void Cycle(int dir)
    {
        charScript.Cycle(dir);
    }
}
