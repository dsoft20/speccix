using UnityEngine;
using System.Collections;

public class setupCamera : MonoBehaviour
{


    void Start()
    {
        this.camera.isOrthoGraphic = true;
        this.camera.orthographicSize = 192 / 2;

        if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer)
        {
            setResolution.resMult = 2;
        }

        if (setupSpeccy.setupOk == false)
        {
            return;
        }

        if (setupSpeccy.have_border)
        {
            this.camera.pixelRect = new Rect(64 * setResolution.resMult, 48 * setResolution.resMult, 256 * setResolution.resMult, 192 * setResolution.resMult); //If the game have a border position the camera at the center
        }
        else
        {
            this.camera.pixelRect = new Rect(0, 0, 256 * setResolution.resMult, 192 * setResolution.resMult); //No border = fill the screen
        }
    }


    void Update()
    {

    }
}
