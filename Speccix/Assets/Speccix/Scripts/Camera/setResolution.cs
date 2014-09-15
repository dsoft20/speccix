using UnityEngine;
using System.Collections;

public class setResolution : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}

    public static int resMult = 1;
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.F1))
        {
            if (setupSpeccy.have_border)
            {
                Screen.SetResolution(384, 288,false);
            }else
            {
                Screen.SetResolution(256, 192, false);
            }
            resMult = 1;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (setupSpeccy.have_border)
            {
                Screen.SetResolution(384*2, 288*2, false);
            }
            else
            {
                Screen.SetResolution(256*2, 192*2, false);
            }
            resMult = 2;
        }

	}

    void OnApplicationQuit()
    {
        if (setupSpeccy.have_border)
        {
            Screen.SetResolution(384, 288, false);
        }
        else
        {
            Screen.SetResolution(256, 192, false);
        }
        resMult = 1;
    }
}
