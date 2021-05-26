using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    private float torqueOffset = 5f;
    private Rigidbody myRB;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

    }

    private float RandomTorque()
    {
        if (transform.name == "Ball(Clone)")
        {
            if (transform.position.x < 0)
            {
                return transform.position.x - torqueOffset;
            }
            else
            {
                return transform.position.x + torqueOffset;
            }
        }
        else if (transform.name == "Icosahedron(Clone)")
        {
            if (transform.position.x < 0)
            {
                return transform.position.y - torqueOffset;
            }
            else
            {
                return transform.position.y + torqueOffset;
            }
        }
        else
        {
            Debug.LogError("nadiennnn");
            return 0;
        }
    }
    void Update()
    {

    }
}
