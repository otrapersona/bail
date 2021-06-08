using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject[] bumperPrefab;
    public GameObject[] ballCount;

    public TextMeshProUGUI textBounces;
    public TextMeshProUGUI textVictory;
    public TextMeshProUGUI textBumpers;
    [SerializeField] private TextMeshProUGUI textBallPos;

    public bool bumperWaiting;
    public bool debugOn = false;
    public float timeScalez;

    private int[] sign = new int[2] { -1, 1 };
    [SerializeField] GameObject[] backgroundLines = new GameObject[9];
    private int goalSpawnRangeX = 5;
    private int goalSpawnRangeY = 5;
    private int goalPosZ = 0;
    private int goalSpawnPosX;
    private int ballSpawnRangeX = 4;
    private int ballPosZ = 0;
    private int bounceCount;
    [SerializeField] private int bumperCount;

    private float goalSpawnPosY = 0;

    private Vector3 goalSpawnPos = new Vector3(0, 0, 0);
    private Vector3 ballSpawnPos;
    private Vector3 bumperPos = new Vector3(-6, 0, -1);
#if UNITY_EDITOR
    private Vector3 newPos;
    private Vector3 oldPos = Vector3.zero;
#endif

    private float ballSpawnRangeY = 5f;
    private float BallSpawnPosY;
    private float ballSpawnPosX = 0;
    void Start()
    {
        bounceCount = 0;
        bumperCount = 0;
        textBounces.text = "BOUNCES\n" + bounceCount;
        //victoryText.gameObject.SetActive(false);
        bumperWaiting = false;
        timeScalez = Time.timeScale;
        GiveMeBalls();
        GiveMegoal();
        GiveMeBumpers();
    }

    public void GiveMeBalls()
    {
        Application.targetFrameRate = 50;
        QualitySettings.vSyncCount = 0;
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugGiveMeBalls");
#endif
        BallSpawnPosY = ballSpawnRangeY - transform.localScale.y / 3;
        ballSpawnPosX = Random.Range(-ballSpawnRangeX, ballSpawnRangeX);
        DisableBGLines();
        EnableBGLine((int)ballSpawnPosX);
        ballSpawnPos = new Vector3(ballSpawnPosX, BallSpawnPosY, ballPosZ);
        Instantiate(ballPrefab, ballSpawnPos, ballPrefab.transform.rotation);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    public void GiveMegoal()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugGiveMeGoal");
#endif
        goalSpawnPosX = (goalSpawnRangeX * sign[Random.Range(0, 2)]);
        goalSpawnPosY = Random.Range(-goalSpawnRangeY + goalPrefab.transform.localScale.y / 2, goalSpawnRangeY - goalPrefab.transform.localScale.y / 2);
        goalSpawnPos = new Vector3(goalSpawnPosX, goalSpawnPosY, goalPosZ);
        Instantiate(goalPrefab, goalSpawnPos, goalPrefab.transform.rotation);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    public void RestartGame()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugRestartGame");
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    public void BallCollided(GameObject theBall, string type)
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugBallCollidedGM");
#endif
        if (type == "bumper")
        {
            bounceCount++;

        }
        else if (type == "edge")
        {
            ResetBall(theBall);
        }
        else if (type == "goal")
        {
            textVictory.gameObject.SetActive(true);
            int finalScore = ((bounceCount - bumperCount + 2) * 100);
            if (finalScore < 1) { textVictory.text = "VICTORY, BUT AT WHAT COST?\nSCORE " + 0 + "\nMORE BUMPERS = LOWER SCORE"; }
            else textVictory.text = "SUPREME VICTORY\nSCORE " + finalScore + "\nMORE BOUNCES = HIGHER SCORE";


            textVictory.gameObject.SetActive(true);
        }
        textBounces.text = "BOUNCES\n" + bounceCount;
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    public void GiveMeBumpers()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugGiveMeBumpers");
#endif
        if (!bumperWaiting)
        {
            int randomBumper = Random.Range(0, bumperPrefab.Length);
            Instantiate(bumperPrefab[randomBumper], bumperPos, bumperPrefab[randomBumper].transform.rotation);
            bumperCount++;
            textBumpers.text = "BUMPERS\n" + (bumperCount - 1);
            bumperWaiting = true;
        }
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    public void ResetBall(GameObject theBall)
    {
        bounceCount = 0;
        if (debugOn)
        {
            BallPosText(theBall);
        }
        theBall.gameObject.transform.position = ballSpawnPos;
        theBall.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
    private void BallPosText(GameObject theBall)
    {
        textBallPos.text = "x\n" + theBall.transform.position.x + "\n\ny\n" + theBall.transform.position.y;
#if UNITY_EDITOR
        newPos = theBall.transform.position;
        if (debugOn && oldPos != newPos)
        {
            Debug.Log("oldPos != newPos");
            Time.timeScale = 0.0f;
        }
        oldPos = newPos;
#endif
    }
    private void Update()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugGameManagerUpdate");
#endif
        if (Input.GetKeyDown(KeyCode.D))
        {
            debugOn = !debugOn;
            textBallPos.gameObject.SetActive(!textBallPos.gameObject.activeSelf);
            textBounces.gameObject.SetActive(!textBounces.gameObject.activeSelf);
            textBumpers.gameObject.SetActive(!textBumpers.gameObject.activeSelf);

        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ResetBall(GameObject.FindGameObjectWithTag("ball"));
        }
#if UNITY_EDITOR
        else if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
#endif
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    private void DisableBGLines()
    {
        foreach (GameObject backgroundLine in backgroundLines)
        {
            backgroundLine.SetActive(false);
        }
    }
    private void EnableBGLine(int xPos)
    {
        backgroundLines[xPos + 4].SetActive(true);
    }
}
