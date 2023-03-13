using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Flap;
    public AudioClip Die;
    public AudioClip Point;

    public static SFXManager SFXInstance;

    public void Awake()
    {
        if (SFXInstance != null && SFXInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SFXInstance = this;
        DontDestroyOnLoad(this);
    }
}