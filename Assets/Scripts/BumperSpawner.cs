using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSpawner : MonoBehaviour
{
    public GameObject[] bumperPrefab;
    private int bumperCounter = 0;
    private Vector3 bumperPos = new Vector3(0, 0, 0);
    void Start()
    {
        InvokeRepeating("GiveMeBumpers", 1, 3);
    }
    void Update()
    { }
    void GiveMeBumpers()
    {
        if (bumperCounter < bumperPrefab.Length)
        {
            Instantiate(bumperPrefab[bumperCounter], bumperPos, bumperPrefab[bumperCounter].transform.rotation);
            bumperCounter += 1;
        }
    }
}
