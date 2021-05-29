using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManagerScript;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManagerScript.BallCollided(gameObject, other.gameObject.tag);
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameManagerScript.BallCollided(gameObject, collision.gameObject.tag);
    }

}
