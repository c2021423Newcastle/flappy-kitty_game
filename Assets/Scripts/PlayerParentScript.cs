using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;
    [SerializeField]
    private GameObject dog;

    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        int charIdx = PlayerPrefs.GetInt("selectedChar", 0);

        switch (charIdx) {
            case 0:
                Instantiate(cat, gameObject.transform);
                break;
            case 1:
                Instantiate(dog, gameObject.transform);
                break;
        }
    }

    public bool GetAlive() 
    {
        return alive;
    }

    public void SetAlive(bool val)
    {
        alive = val;
    }
}
