using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountScript : MonoBehaviour
{       
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }
}
