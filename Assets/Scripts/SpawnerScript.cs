using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private float pipeSpawnRate = 2;
    private float pipeTimer = 0;
    private float coinTimer;
    [SerializeField]
    private float heightOffset = 6;
    private PlayerParentScript playerScript;
    private int coinChance;

    // Start is called before the first frame update
    void Start()
    {
        coinTimer = pipeSpawnRate / 2;
        coinChance = PlayerPrefs.GetInt("difficulty", 1);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParentScript>();
        Spawn(pipe);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.GetAlive())
        {
            if (pipeTimer < pipeSpawnRate)
            {
                pipeTimer += Time.deltaTime;
            } 
            else
            {
                Spawn(pipe);
                pipeTimer = 0;
            }

            

            if (coinTimer < pipeSpawnRate) 
            {
                coinTimer += Time.deltaTime;
            }
            else 
            {
                int rInt = Random.Range(0, 10);

                if (rInt < coinChance) 
                {
                    Spawn(coin);
                }
                coinTimer = 0;
            }
        }
    }

    void Spawn(GameObject obj)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(obj, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
