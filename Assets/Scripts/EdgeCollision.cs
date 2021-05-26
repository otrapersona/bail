using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollision : MonoBehaviour
{
    public GameObject spawner;
    private GameManager ballSpawnScript;

    private void Start()
    {
        ballSpawnScript = spawner.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            Destroy(other.gameObject);
            ballSpawnScript.GiveMeBalls();
        }
    }
}
