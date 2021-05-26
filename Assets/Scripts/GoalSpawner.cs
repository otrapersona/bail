using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject goalPrefab;
    private int[] sign = new int[2] { -1, 1 };
    private int goalSpawnRangeX = 5;
    private int goalSpawnRangeY = 5;
    private int goalPosZ = 0;
    private int goalSpawnPosY = 0;
    private Vector3 goalSpawnPos = new Vector3(0, 0, 0);
    private int goalSpawnPosX;
    void Start()
    {
        GiveMegoal();
    }

    void Update()
    { }
    void GiveMegoal()
    {
        goalSpawnPosX = goalSpawnRangeX * sign[Random.Range(0, 2)];
        goalSpawnPosY = Random.Range(-goalSpawnRangeY, goalSpawnRangeY);
        goalSpawnPos = new Vector3(goalSpawnPosX, goalSpawnPosY, goalPosZ);
        Instantiate(goalPrefab, goalSpawnPos, goalPrefab.transform.rotation);
    }
}
