using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Ball : MonoBehaviour
{
    private GameManager gameManagerScript;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugBallTrigger");
#endif
        gameManagerScript.BallCollided(gameObject, other.gameObject.tag);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    private void OnCollisionEnter(Collision collision)
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugBallCollision");
#endif
        gameManagerScript.BallCollided(gameObject, collision.gameObject.tag);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }

}
