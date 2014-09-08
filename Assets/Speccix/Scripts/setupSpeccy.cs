using UnityEngine;
using System.Collections;

public class setupSpeccy : MonoBehaviour
{


    void OnEnable()
    {
        Screen.SetResolution(384, 288, false);
    }

    void Start()
    {
        if (Application.platform != RuntimePlatform.WindowsWebPlayer && Application.platform != RuntimePlatform.WindowsWebPlayer)
        {
            Screen.SetResolution(384, 288, false);
        }
      
        border_colors = new Color[8] { new Color(0, 0, 0, 1), new Color(0, 0, dim, 1), new Color(dim, 0, 0, 1), new Color(dim, 0, dim, 1), new Color(0, dim, 0, 1), new Color(0, dim, dim, 1), new Color(dim, dim, 0, 1), new Color(dim, dim, dim, 1) };
        have_border = border; //have border will be used to resize & position the camera on other scenes.

        if (border)
        {
            if (Application.platform != RuntimePlatform.WindowsWebPlayer && Application.platform !=  RuntimePlatform.OSXWebPlayer)
            {
                Screen.SetResolution(384, 288, false);
            }

            //Create the texture, then set is to wrap mode Clamp and filter mode point
            border_texture = new Texture2D(384, 288, TextureFormat.ARGB32, false);
            border_texture.wrapMode = TextureWrapMode.Clamp;
            border_texture.filterMode = FilterMode.Point;
            Debug.Log("1");

            fillRect(0, 0, 384, 288, new Color(0, 0, 0, 0), border_texture); //Fill the texture with trasparent color
            fillRect(0, 0, 386, 48, border_colors[curr_border_color - 1], border_texture); //Top border
            fillRect(0, 240, 386, 48, border_colors[curr_border_color - 1], border_texture); //Bottom border
            fillRect(0, 0, 64, 288, border_colors[curr_border_color - 1], border_texture); //Left border
            fillRect(320, 0, 64, 288, border_colors[curr_border_color - 1], border_texture); //Right border
            Debug.Log("2");

            GameObject borderCamera = new GameObject("border_camera");
            DontDestroyOnLoad(borderCamera); //The camera will not be destroyed at scene change :D
            borderCamera.AddComponent("Camera"); //Add the camera component
            borderCamera.camera.isOrthoGraphic = true; //Set the camera in ortographic mode
            borderCamera.camera.clearFlags = CameraClearFlags.Depth;
            borderCamera.camera.orthographicSize = 288 / 2; //Pixel perfect
            Debug.Log("3");

            GameObject border_quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            border_quad.name = "border_quad";
            DontDestroyOnLoad(border_quad); //The border will not be destroyed at scene change :D
            border_quad.transform.parent = borderCamera.transform; //Set the quad parent to the border_camera
            border_quad.transform.localPosition = new Vector3(0, 0, 10); // Position & resize the border_quad so it can fill the screen
            border_quad.transform.localScale = new Vector3(384, 288, 1);
            border_quad.renderer.material.shader = Shader.Find("Unlit/Transparent Cutout"); //Assign the Unlit alpha test shader
            border_quad.renderer.material.mainTexture = border_texture; //Assign the border texture
            Debug.Log("4");

            borderCamera.transform.position = new Vector3(0, 0, -1000);
            borderCamera.transform.Rotate(0, 180, 0);
            borderCamera.AddComponent("setResolution");
            Debug.Log("5");
        }
        else //If the game doesn't have border set the resolution to the Speccy default 256x192 
        {
            if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer)
            {
                return;
            }
            Screen.SetResolution(256, 192, false);
        }
        
        Application.targetFrameRate = framerate;
        setupOk = true;
    }

    public bool border = false;
    Texture2D border_texture;
    Color[] border_colors;
    public int curr_border_color = 0;
    public int framerate = 25;
    float dim = 0.803921568627451f;

    public static bool setupOk = false;
    

    public static bool have_border = false;

    void Update() //Only for test project, it can be deleted
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("cameraRectTest");
        }
    }

    void fillRect(int _x, int _y, int _widht, int _height, Color _color, Texture2D _texture)
    {
        for (int x = _x; x < _x + _widht; x++)
        {
            for (int y = _y; y < _y + _height; y++)
            {
                _texture.SetPixel(x, y, _color);
            }
        }
        _texture.Apply();
    }
}
