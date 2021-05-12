using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject goalPrefab;
    private int[] sign = new int[2] { -1, 1 };
    private int spawnRangeX = 8;
    private int spawnRangeY = 4;
    private int goalPosZ = 0;
    private int spawnPosY = 0;
    private Vector3 spawnPos = new Vector3(0, 0, 0);
    private int spawnPosX;
    void Start()
    {
        GiveMegoal();
    }

    void Update()
    { }
    void GiveMegoal()
    {
        spawnPosX = spawnRangeX * sign[Random.Range(0, 2)];
        spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        spawnPos = new Vector3(spawnPosX, spawnPosY, goalPosZ);
        Instantiate(goalPrefab, spawnPos, goalPrefab.transform.rotation);
    }
}
