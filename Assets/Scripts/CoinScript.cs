using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private LogicScript logic;
    [SerializeField]
    private BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && bird.GetAlive())
        {
            logic.AddCoin();
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Coin);
            Destroy(gameObject);
        }
    }
}
