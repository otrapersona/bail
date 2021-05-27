using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLetterBox : MonoBehaviour
{
    private float targetAspectRatio = 1.2f;
        //= 16f/9f;
    private Camera mainCam;
    void Start()
    {
        mainCam = gameObject.GetComponent<Camera>();
        InvokeRepeating("GoHamWithTheCam", 0, 1);
    }
    void Update()
    {
        
    }
    public void GoHamWithTheCam()
    {
            float w = Screen.width;
            float h = Screen.height;
            float a = w / h;
            Rect r;
            if (a > targetAspectRatio)
            {
                float tw = h * targetAspectRatio;
                float o = (w - tw) * 0.5f;
                r = new Rect(o, 0, tw, h);
            }
            else
            {
                float th = w / targetAspectRatio;
                float o = (h - th) * 0.5f;
                r = new Rect(0, o, w, th);
            }
            mainCam.pixelRect = r;
    }
}
