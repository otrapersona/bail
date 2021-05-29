using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject[] bumperPrefab;
    public GameObject[] ballCount;

    public TextMeshProUGUI textBounces;
    public TextMeshProUGUI textVictory;

    public bool bumperWaiting;

    private int[] sign = new int[2] { -1, 1 };
    private int goalSpawnRangeX = 5;
    private int goalSpawnRangeY = 5;
    private int goalPosZ = 0;
    private int goalSpawnPosX;
    private int ballSpawnRangeX = 4;
    private int ballPosZ = 0;
    private int bounces;

    private float goalSpawnPosY = 0;

    private Vector3 goalSpawnPos = new Vector3(0, 0, 0);
    private Vector3 ballSpawnPos;
    private Vector3 bumperPos = new Vector3(-6, 0, -1);

    private float ballSpawnRangeY = 5f;
    private float BallSpawnPosY;
    private float ballSpawnPosX = 0;
    void Start()
    {
        bounces = 0;
        textBounces.text = "BOUNCES\n" + bounces;
        //victoryText.gameObject.SetActive(false);
        bumperWaiting = false;
        Time.timeScale = 1f;
        GiveMeBalls();
        GiveMegoal();
        GiveMeBumpers();
    }
    void Update()
    {
    }
    public void GiveMeBalls()
    {
        //ballCount = GameObject.FindGameObjectsWithTag("ball");
        //if (ballCount.Length < 2)
        //{
        //    if (ballSpawnPos == new Vector3(0, 0, 0))
        //    {
                BallSpawnPosY = ballSpawnRangeY - transform.localScale.y / 3;
                ballSpawnPosX = Random.Range(-ballSpawnRangeX, ballSpawnRangeX);
                ballSpawnPos = new Vector3(ballSpawnPosX, BallSpawnPosY, ballPosZ);
            //}
            Instantiate(ballPrefab, ballSpawnPos, ballPrefab.transform.rotation);
        //}
    }
    public void GiveMegoal()
    {
        goalSpawnPosX = (goalSpawnRangeX * sign[Random.Range(0, 2)]);
        goalSpawnPosY = Random.Range(-goalSpawnRangeY + goalPrefab.transform.localScale.y / 2, goalSpawnRangeY - goalPrefab.transform.localScale.y / 2);
        goalSpawnPos = new Vector3(goalSpawnPosX, goalSpawnPosY, goalPosZ);
        Instantiate(goalPrefab, goalSpawnPos, goalPrefab.transform.rotation);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//loads scene. which one? the current one
    }
    public void BallCollided(GameObject theBall, string type)
    {

        if (type == "bumper")
        {
            bounces++;
            
        }
        else if (type == "edge")
        {
            ResetBall(theBall);
        }
        else if (type == "goal")
        {
            textVictory.text = "SUPREME VICTORY\nSCORE\n" + Mathf.Pow(bounces, 2);
            textVictory.gameObject.SetActive(true);
        }
        textBounces.text = "BOUNCES\n" + bounces;
    }
    public void GiveMeBumpers()
    {
        if (!bumperWaiting)
        {
            int randomBumper = Random.Range(0, bumperPrefab.Length);
            Instantiate(bumperPrefab[randomBumper], bumperPos, bumperPrefab[randomBumper].transform.rotation);
            bumperWaiting = true;
        }
    }
    public void ResetBall(GameObject theBall)
    {
        bounces = 0;
        //Destroy(theBall.gameObject);
        theBall.gameObject.transform.position = ballSpawnPos;
        theBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //GiveMeBalls();
    }
}
