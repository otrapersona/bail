using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraLetterBox : MonoBehaviour
{
    private float targetWidthResolution = 960;

    private float targetHeightResolution = 800;

    private float targetAspectRatio; // 960/800 = 1.2

    private Camera mainCam;

    void Start()
    {
        targetAspectRatio = targetWidthResolution / targetHeightResolution;
        mainCam = gameObject.GetComponent<Camera>();
        InvokeRepeating("GoHamWithTheCam", 0, 0.25f);
    }

    public void GoHamWithTheCam()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("DebugGoHamWithTheCam");
#endif
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
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }
}
