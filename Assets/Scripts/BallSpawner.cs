using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    private float spawnRangeX = 7f;
    private float spawnPosY = 4.2f;
    private int ballPosZ = 0;
    private float spawnPosX = 0;
    private Vector3 spawnPos = new Vector3(0, 0, 0);
    void Start()
    { 
        InvokeRepeating("GiveMeBalls", 0, .333f);
    }

    void Update()
    {}
    void GiveMeBalls()
    {
        if (spawnPos == new Vector3(0, 0, 0))
        {
            spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
            spawnPos = new Vector3(spawnPosX, spawnPosY, ballPosZ);
        }
        //Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
        //test
        Instantiate(ballPrefab, new Vector3(0, spawnPosY, ballPosZ), ballPrefab.transform.rotation);
    }
}
