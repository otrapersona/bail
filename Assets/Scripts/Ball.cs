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
        UnityEngine.Profiling.Profiler.BeginSample("DebugBallTrigger");
        gameManagerScript.BallCollided(gameObject, other.gameObject.tag);
        UnityEngine.Profiling.Profiler.EndSample();
    }
    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Profiling.Profiler.BeginSample("DebugBallCollision");
        gameManagerScript.BallCollided(gameObject, collision.gameObject.tag);
        UnityEngine.Profiling.Profiler.EndSample();
    }

}
