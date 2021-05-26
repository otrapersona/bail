using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSpawner : MonoBehaviour
{
    public GameObject[] bumperPrefab;
    public bool bumperWaiting;
    private Vector3 bumperPos = new Vector3(-6, 0, -1);
    void Start()
    {
        bumperWaiting = false;
    }
    void Update()
    {
        GiveMeBumpers();
    }
    void GiveMeBumpers()
    {
        if (!bumperWaiting)
        {
            int randomBumper = Random.Range(0, bumperPrefab.Length);
            Instantiate(bumperPrefab[randomBumper], bumperPos, bumperPrefab[randomBumper].transform.rotation);
            bumperWaiting = true;
        }
    }
}
