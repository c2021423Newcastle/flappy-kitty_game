using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private GameObject coin;
    private float spawnRate;
    private float pipeTimer = 0;
    private float coinTimer;
    [SerializeField]
    private float heightOffset = 6;
    private PlayerParentScript playerScript;
    private int coinChance;
    private int odds = 10;

    // Start is called before the first frame update
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);

        switch (difficulty) {
            case 1:
                spawnRate = 4;
                break;
            case 2:
                spawnRate = 3;
                break;
            case 3:
                spawnRate = 2;
                break;
        }

        coinTimer = spawnRate / 2;
        coinChance = difficulty;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParentScript>();
        Spawn(pipe);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.GetAlive())
        {
            if (pipeTimer < spawnRate)
            {
                pipeTimer += Time.deltaTime;
            } 
            else
            {
                Spawn(pipe);
                pipeTimer = 0;
            }

            if (coinTimer < spawnRate)
            {
                coinTimer += Time.deltaTime;
            }
            else 
            {
                int rInt = Random.Range(0, odds);

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
