using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountScript : MonoBehaviour
{       
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateCount();
    }

    public void UpdateCount()
    {
        text.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }
}
