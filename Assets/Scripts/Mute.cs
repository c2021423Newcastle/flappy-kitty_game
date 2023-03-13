using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public void Start()
    {
        int muted = PlayerPrefs.GetInt("muted", 0);

        if (muted == 1)
        {
            GameObject toggle = GameObject.Find("Toggle");
            toggle.GetComponent<Toggle>().isOn = true;
        }
    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("muted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("muted", 0);
            PlayerPrefs.Save();
        }
    }
}
