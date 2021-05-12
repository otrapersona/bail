using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRotate : MonoBehaviour
{

    public int rotationRange = 180;
    void Start()
    {
        int bumperRotation = Random.Range(0, rotationRange);
        transform.Rotate(Vector3.forward, bumperRotation);
    }

    // Update is called once per frame
    void Update()
    {      

    }
}
