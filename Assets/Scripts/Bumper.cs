using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Bumper : MonoBehaviour
{
    private Camera cam;
    float camNearClipPlane;
    float camPosZ;
    private int rotationRange = 360;
    private bool amIDraggable;
    private GameManager gameManagerScript;
    public MeshCollider[] meshCollider;
    public BoxCollider boxCollider;
    private float limitX = 5f;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        amIDraggable = true;
        cam = Camera.main;
        camNearClipPlane = cam.nearClipPlane;
        camPosZ = cam.transform.position.z;
        int bumperRotation = Random.Range(0, rotationRange / 15) * 15;
        transform.Rotate(Vector3.forward, bumperRotation);
    }

    private void OnMouseDrag()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugBumperOnMouseDrag");
#endif
        if (amIDraggable)
        {
            Time.timeScale = 0.0f;
            Vector3 mousePos = new Vector2();
            Vector3 point = new Vector3();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            mousePos.z = camNearClipPlane - camPosZ;
            point = cam.ScreenToWorldPoint(mousePos);
            transform.position = point;


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
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
    private void OnMouseUp()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugBumperOnMouseUp");
#endif
        if (amIDraggable)
        {

            gameManagerScript.bumperWaiting = false;
            meshCollider[0].enabled = true;
            meshCollider[1].enabled = true;
            boxCollider.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            amIDraggable = false;
            gameManagerScript.GiveMeBumpers();
            Time.timeScale = gameManagerScript.timeScalez;
        }
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
}
