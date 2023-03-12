using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Canvas canvas;


    public void SwitchCam(int x)
    {

        deactivateAll();
        if (x == 1)
        {
            cam1.enabled = true;
        }
        else if (x == 2)
        {
            cam2.enabled = true;
            canvas.enabled = false;
        }
    }

    public void deactivateAll()
    {
        cam1.enabled = false;
        cam2.enabled = false;
    }
}
