using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyMaterial : MonoBehaviour
{
    public Vector2 zing;
    public float scaleFactor = 4f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TilingChanger();
    }
    void TilingChanger() //YEAH BOIIIII usar al instanciar bumpers más largos ó cortossssssssss para que no se estire la textura antifashionmente
    {
        zing = new Vector2(transform.localScale.x / scaleFactor , transform.localScale.x * scaleFactor);
        GetComponent<Renderer>().material.mainTextureScale = zing;
    }
}
