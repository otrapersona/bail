using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Camera cam;
    float camNearClipPlane;
    float camPosZ;
    public int rotationRange = 180;
    private bool amIDraggable;
    private BumperSpawner bumperSpawnerScript;
    private MeshCollider meshCollider;
    private bool beingDragged = false;
    void Start()
    {
        bumperSpawnerScript = GameObject.Find("Spawner").GetComponent<BumperSpawner>();
        meshCollider = GetComponent<MeshCollider>();
        amIDraggable = true;
        cam = Camera.main;
        camNearClipPlane = cam.nearClipPlane;
        camPosZ = cam.transform.position.z;
        int bumperRotation = Random.Range(0, rotationRange);
        transform.Rotate(Vector3.up, bumperRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!amIDraggable || beingDragged)
        {
            if (transform.position.x > 5)
            {
                transform.position = new Vector3(5, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -5)
            {
                transform.position = new Vector3(-5, transform.position.y, transform.position.z);
            }
            if (transform.position.y > 5)
            {
                transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            }
            else if (transform.position.y < -5)
            {
                transform.position = new Vector3(transform.position.x, -5, transform.position.z);
            }

        }
    }

    private void OnMouseDrag()
    {
        if (amIDraggable)
        {
            beingDragged = true;
            Vector3 mousePos = new Vector2();
            Vector3 point = new Vector3();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            mousePos.z = camNearClipPlane - camPosZ;
            point = cam.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(2 * (float)System.Math.Round(point.x / 2, 1), 2 * (float)System.Math.Round(point.y / 2, 1), point.z);
        }
    }
    private void OnMouseUp()
    {
        amIDraggable = false;
        bumperSpawnerScript.bumperWaiting = false;
        meshCollider.enabled = true;
    }
}