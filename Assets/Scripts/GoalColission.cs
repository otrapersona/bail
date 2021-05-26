using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalColission : MonoBehaviour
{
    private GameObject victoryText;

    void Start()
    {
        victoryText = GameObject.Find("Victory Text");
        victoryText.gameObject.SetActive(false);
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
            victoryText.gameObject.SetActive(true);
        }
    }
}
