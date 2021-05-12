using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnAndColission : MonoBehaviour
{
    public GameObject ballPrefab;
    private float spawnRangeX = 7f;
    private float spawnPosY = 4.2f;
    private int ballPosZ = 0;
    private float spawnPosX = 0;
    private Vector3 spawnPos = new Vector3(0, 0, 0);
    void Start()
    {
        GiveMeBalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            Destroy(other.gameObject);
            GiveMeBalls();
        }
    }
    public void GiveMeBalls()
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
