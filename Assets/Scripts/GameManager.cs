using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    private int[] sign = new int[2] { -1, 1 };
    private int goalSpawnRangeX = 5;
    private int goalSpawnRangeY = 5;
    private int goalPosZ = 0;
    private int goalSpawnPosY = 0;
    private Vector3 goalSpawnPos = new Vector3(0, 0, 0);
    private int goalSpawnPosX;
    private float ballSpawnRangeX = 5f;
    private float ballSpawnRangeY = 5f;
    private float BallSpawnPosY;
    private int ballPosZ = 0;
    private float ballSpawnPosX = 0;
    private Vector3 ballSpawnPos ;
    void Start()
    {
        ballSpawnPos = new Vector3(0, 0, 0);
        GiveMeBalls();
        GiveMegoal();
    }
    void Update()
    {

    }
    public void GiveMeBalls()
    {
        if (ballSpawnPos == new Vector3(0, 0, 0))
        {
            BallSpawnPosY = ballSpawnRangeY - transform.localScale.y / 3;
            ballSpawnPosX = Random.Range(-ballSpawnRangeX + transform.localScale.y / 3, ballSpawnRangeX - transform.localScale.y / 3);
            ballSpawnPos = new Vector3(ballSpawnPosX, BallSpawnPosY, ballPosZ);
        }
        Instantiate(ballPrefab, ballSpawnPos, ballPrefab.transform.rotation);
    }
    public void GiveMegoal()
    {
        goalSpawnPosX = goalSpawnRangeX * sign[Random.Range(0, 2)];
        goalSpawnPosY = Random.Range(-goalSpawnRangeY, goalSpawnRangeY);
        goalSpawnPos = new Vector3(goalSpawnPosX, goalSpawnPosY, goalPosZ);
        Instantiate(goalPrefab, goalSpawnPos, goalPrefab.transform.rotation);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//loads scene. which one? the current one
    }
}
