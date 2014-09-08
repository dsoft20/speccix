using UnityEngine;
using System.Collections;

public class attributeClash : MonoBehaviour
{


    void Start()
    {
        colors.filterMode = FilterMode.Point;
        colors.wrapMode = TextureWrapMode.Clamp;

        b_attribute_clash = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        b_attribute_clash.wrapMode = TextureWrapMode.Clamp;
        b_attribute_clash.filterMode = FilterMode.Point;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                b_attribute_clash.SetPixel(x, y, colors.GetPixel(x, y));
            }
        }

        b_attribute_clash.Apply();


        unedited_clash = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        unedited_clash.filterMode = FilterMode.Point;
        unedited_clash.wrapMode = TextureWrapMode.Clamp;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                unedited_clash.SetPixel(x, y, b_attribute_clash.GetPixel(x, y));
            }
        }

        unedited_clash.Apply();

    }

    public void reloadColors(Texture2D _tex)
    {
        colors = _tex;
        colors.filterMode = FilterMode.Point;
        colors.wrapMode = TextureWrapMode.Clamp;

        b_attribute_clash = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        b_attribute_clash.wrapMode = TextureWrapMode.Clamp;
        b_attribute_clash.filterMode = FilterMode.Point;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                b_attribute_clash.SetPixel(x, y, colors.GetPixel(x, y));
            }
        }

        b_attribute_clash.Apply();


        unedited_clash = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        unedited_clash.filterMode = FilterMode.Point;
        unedited_clash.wrapMode = TextureWrapMode.Clamp;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                unedited_clash.SetPixel(x, y, b_attribute_clash.GetPixel(x, y));
            }
        }

        unedited_clash.Apply();
    }


    public Texture2D colors;
    public bool draw_attribute_grid = false;
    public static Texture2D b_attribute_clash;
    public static Texture2D unedited_clash;
    public static Color[] palette = new Color[16] { new Color(0, 0, 0, 1), new Color(0, 0, 205, 1), new Color(205, 0, 0, 1), new Color(205, 0, 205, 1), new Color(0, 205, 0, 1), new Color(0, 205, 205, 1), new Color(205, 205, 0, 1), new Color(205, 205, 205, 1), 
                                    new Color(0,0,0,1), new Color(0,0,255,1), new Color(255,0,0,1), new Color(255,0,255,1), new Color(0,255,0,1), new Color(0,255,255,1), new Color(255,255,0,1), new Color(255,255,255,1)};



    void Update()
    {

        end();

        if (draw_attribute_grid)
        {
            drawAttributeGrid();
        }
    }

    void LateUpdate()
    {

    }

    public static void start()
    {
        clear();
    }

    public static void clear()
    {
        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                b_attribute_clash.SetPixel(x, y, unedited_clash.GetPixel(x, y));
            }
        }

        b_attribute_clash.Apply();
    }

    public static void draw(int _x, int _y, int _color)
    {

        if (_x < 0 || _x >= 32)
        {
            return;
        }

        b_attribute_clash.SetPixel(_x, 23 - _y, palette[_color - 1]);

    }

    public static void drawPermanent(int _x, int _y, int _color)
    {
        unedited_clash.SetPixel(_x, 23 - _y, palette[_color - 1]);
    }

    public static void end()
    {
        b_attribute_clash.Apply();
    }

    void drawAttributeGrid()
    {
        for (int x = -128; x < 128; x += 8)
        {
            Debug.DrawLine(new Vector3(x, -1000, 10), new Vector3(x, 1000, 10), new Color(0.08f, 0.08f, 0.08f, 10));
        }

        for (int y = -96; y < 96; y += 8)
        {
            Debug.DrawLine(new Vector3(-1000, y, 10), new Vector3(1000, y, 10), new Color(0.08f, 0.08f, 0.08f, 10));
        }
    }
}
