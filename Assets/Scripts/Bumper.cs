using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Camera cam;
    float camNearClipPlane;
    float camPosZ;
    private int rotationRange = 180;
    private bool amIDraggable;
    private GameManager gameManagerScript;
    public MeshCollider[] meshCollider;
    public BoxCollider boxCollider;
    private float limitX = 4.9f;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        amIDraggable = true;
        cam = Camera.main;
        camNearClipPlane = cam.nearClipPlane;
        camPosZ = cam.transform.position.z;
        int bumperRotation = Random.Range(0, rotationRange / 10) * 10;
        transform.Rotate(Vector3.forward, bumperRotation);
    }

    private void OnMouseDrag()
    {
        if (amIDraggable)
        {
            Vector3 mousePos = new Vector2();
            Vector3 point = new Vector3();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            mousePos.z = camNearClipPlane - camPosZ;
            point = cam.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3((float)System.Math.Round(point.x, 2), (float)System.Math.Round(point.y, 2), (float)System.Math.Round(point.z, 2));

            if (transform.position.x > limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -limitX)
            {
                transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
            }
            if (transform.position.y > limitX)
            {
                transform.position = new Vector3(transform.position.x, limitX, transform.position.z);
            }
            else if (transform.position.y < -limitX)
            {
                transform.position = new Vector3(transform.position.x, -limitX, transform.position.z);
            }
        }
    }
    private void OnMouseUp()
    {
        if (amIDraggable)
        {

            gameManagerScript.bumperWaiting = false;
            meshCollider[0].enabled = true;
            meshCollider[1].enabled = true;
            boxCollider.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            amIDraggable = false;
            gameManagerScript.GiveMeBumpers();
        }
    }
}
