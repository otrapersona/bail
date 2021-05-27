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
        if (other.gameObject.tag == "edge" || other.gameObject.tag == "goal")
        {
            gameManagerScript.BallCollided(gameObject, other.gameObject.tag);

        }
    }
}
