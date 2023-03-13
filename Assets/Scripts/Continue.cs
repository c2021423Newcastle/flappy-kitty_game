using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    private BirdScript birdScript;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    public void Reset()
    {
        Destroy(birdScript.GetCollidedObject());
        birdScript.ResetPosition();
        gameOverScreen.SetActive(false);
    }
}
