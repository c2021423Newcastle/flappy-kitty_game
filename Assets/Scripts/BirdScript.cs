using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool alive = true;
    public float rotateRate = 0.1F;
    private GameObject collidedObject;
    public GameObject animationSprite;
    public GameObject deadSprite;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -16 || transform.position.y > 16)
        {
            Died();
        }
        else if (alive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
                transform.eulerAngles = new Vector3(0, 0, 45);
                SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Flap);
            }
            else if (transform.eulerAngles.z > 315 || transform.eulerAngles.z < 45.1)
            {
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - (rotateRate));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.gameObject.transform.parent.gameObject;
        Died();
    }

    public bool GetAlive()
    {
        return alive;
    }

    public GameObject GetCollidedObject()
    {
        return collidedObject;
    }

    private void Died()
    {
        animationSprite.SetActive(false);
        deadSprite.SetActive(true);
        logic.gameOver();
        alive = false;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(-2.5F, 0, 0);
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.angularVelocity = 0;
        transform.eulerAngles = new Vector3(0, 0, 45);
        alive = true;
        animationSprite.SetActive(true);
        deadSprite.SetActive(false);
    }
}
