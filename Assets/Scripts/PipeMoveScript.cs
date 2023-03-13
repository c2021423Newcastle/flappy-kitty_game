using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float deadZone = 0;
    private BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {
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
