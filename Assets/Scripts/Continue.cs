using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    private PlayerScript playerScript;
    [SerializeField]
    private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    public void Reset()
    {
        Destroy(playerScript.GetCollidedObject());
        playerScript.ResetPosition();
        gameOverScreen.SetActive(false);
    }
}
