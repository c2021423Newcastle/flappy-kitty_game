using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveScript : MonoBehaviour
{
    private float moveSpeed;
    [SerializeField]
    private float deadZone = 0;
    private BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {   
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);

        switch (difficulty)
        {
            case 1:
                moveSpeed = 5.5F;
                break;
            case 2:
                moveSpeed = 7.5F;
                break;
            case 3:
                moveSpeed = 9.5F;
                break;
        }

        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.GetAlive())
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
