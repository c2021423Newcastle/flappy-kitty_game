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
        int skinNumber = PlayerPrefs.GetInt("selectedSkin", 0);

        switch (skinNumber) {
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
