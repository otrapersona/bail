using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColission : MonoBehaviour
{
    public GameObject victoryPrefab;
    void Start()
    {

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
            //Debug.Log("you reached the goal and won.\nthere are no more empires to conquer.\nis this a victory or a loss?");
            Instantiate(victoryPrefab);
            Time.timeScale = 0;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("mywife");
    }
}
