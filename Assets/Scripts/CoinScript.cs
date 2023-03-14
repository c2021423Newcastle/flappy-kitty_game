using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private LogicScript logic;
    [SerializeField]
    private PlayerParentScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParentScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && playerScript.GetAlive())
        {
            logic.AddCoin();
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Coin);
            Destroy(gameObject);
        }
    }
}
