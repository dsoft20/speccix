using UnityEngine;
using System.Collections;

public class attributeClash : MonoBehaviour
{
    void Start()
    {
        //p_color initialization, if no texture is passed to the script then create a 32x24 texture filled with black
        if (p_colors == null)
        {
            p_colors = new Texture2D(32,24,TextureFormat.ARGB32,false);

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    p_colors.SetPixel(x, y, Color.black);
                }
            }
        }

        p_colors.filterMode = FilterMode.Point;
        p_colors.wrapMode = TextureWrapMode.Clamp;


        //i_color initialization, if no texture is passed to the script then create a 32x24 texture filled with black
        if (i_colors == null)
        {
            i_colors = new Texture2D(32, 24, TextureFormat.ARGB32, false);

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    i_colors.SetPixel(x, y, Color.black);
                }
            }
        }

        i_colors.filterMode = FilterMode.Point;
        i_colors.wrapMode = TextureWrapMode.Clamp;

       
        //Paper attribute initialization
        p_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        p_attribute.wrapMode = TextureWrapMode.Clamp;
        p_attribute.filterMode = FilterMode.Point;

        p_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        p_attribute.wrapMode = TextureWrapMode.Clamp;
        p_attribute.filterMode = FilterMode.Point;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                p_attribute.SetPixel(x, y, p_colors.GetPixel(x, y));
            }
        }

        p_attribute.Apply();


        p_unedited = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        p_unedited.filterMode = FilterMode.Point;
        p_unedited.wrapMode = TextureWrapMode.Clamp;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                p_unedited.SetPixel(x, y, p_attribute.GetPixel(x, y));
            }
        }

        p_unedited.Apply();

        //Ink attribute initialization
        i_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        i_attribute.wrapMode = TextureWrapMode.Clamp;
        i_attribute.filterMode = FilterMode.Point;

        i_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        i_attribute.wrapMode = TextureWrapMode.Clamp;
        i_attribute.filterMode = FilterMode.Point;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                i_attribute.SetPixel(x, y, i_colors.GetPixel(x, y));
            }
        }

        i_attribute.Apply();


        i_unedited = new Texture2D(32, 24, TextureFormat.ARGB32, false);
        i_unedited.filterMode = FilterMode.Point;
        i_unedited.wrapMode = TextureWrapMode.Clamp;

        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                i_unedited.SetPixel(x, y, i_attribute.GetPixel(x, y));
            }
        }

        i_unedited.Apply();

    }

    public void reload_colors(Texture2D _tex, bool _paper)
    {
        if (_paper)
        {
            p_colors = _tex;
            p_colors.filterMode = FilterMode.Point;
            p_colors.wrapMode = TextureWrapMode.Clamp;


            //Paper attribute color matrix
            p_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
            p_attribute.wrapMode = TextureWrapMode.Clamp;
            p_attribute.filterMode = FilterMode.Point;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    p_attribute.SetPixel(x, y, p_colors.GetPixel(x, y));
                }
            }

            p_attribute.Apply();

            p_unedited = new Texture2D(32, 24, TextureFormat.ARGB32, false);
            p_unedited.filterMode = FilterMode.Point;
            p_unedited.wrapMode = TextureWrapMode.Clamp;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    p_unedited.SetPixel(x, y, p_attribute.GetPixel(x, y));
                }
            }

            p_unedited.Apply();
        }
        else
        {
            //Ink attribute initialization
            i_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
            i_attribute.wrapMode = TextureWrapMode.Clamp;
            i_attribute.filterMode = FilterMode.Point;

            i_attribute = new Texture2D(32, 24, TextureFormat.ARGB32, false);
            i_attribute.wrapMode = TextureWrapMode.Clamp;
            i_attribute.filterMode = FilterMode.Point;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    i_attribute.SetPixel(x, y, p_colors.GetPixel(x, y));
                }
            }

            i_attribute.Apply();


            i_unedited = new Texture2D(32, 24, TextureFormat.ARGB32, false);
            i_unedited.filterMode = FilterMode.Point;
            i_unedited.wrapMode = TextureWrapMode.Clamp;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    i_unedited.SetPixel(x, y, i_attribute.GetPixel(x, y));
                }
            }

            i_unedited.Apply();
        }
    }


    public Texture2D p_colors;
    public Texture2D i_colors;

    public bool draw_attribute_grid = false;

    public static Texture2D p_attribute;
    public static Texture2D i_attribute;

    public static Texture2D p_unedited;
    public static Texture2D i_unedited;

    public static Color[] palette = new Color[16] { new Color(0, 0, 0, 1), new Color(0, 0, 0.803921568627451f, 1), new Color(0.803921568627451f, 0, 0, 1), new Color(0.803921568627451f, 0, 0.803921568627451f, 1), new Color(0, 0.803921568627451f, 0, 1), new Color(0, 0.803921568627451f, 0.803921568627451f, 1), new Color(0.803921568627451f, 0.803921568627451f, 0, 1), new Color(0.803921568627451f, 0.803921568627451f, 0.803921568627451f, 1), 
                                    new Color(0,0,0,1), new Color(0,0,1,1), new Color(1,0,0,1), new Color(1,0,1,1), new Color(0,1,0,1), new Color(0,1,1,1), new Color(1,1,0,1), new Color(1,1,1,1)};

    void Update()
    {
        end();

        if (draw_attribute_grid)
        {
            drawAttributeGrid();
        }
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
                p_attribute.SetPixel(x, y, p_unedited.GetPixel(x, y));
                i_attribute.SetPixel(x, y, i_unedited.GetPixel(x, y));
            }
        }

        p_attribute.Apply();
        i_attribute.Apply();
    }

    public static void draw(int _x, int _y, int _color, bool _paper)
    {
        if (_x < 0 || _x >= 32)
        {
            return;
        }

        if (_paper)
        {
            p_attribute.SetPixel(_x, 23 - _y, palette[_color - 1]);
        }else
        {
            i_attribute.SetPixel(_x, 23 - _y, palette[_color - 1]);
        }
    }

    public static void drawPermanent(int _x, int _y, int _color, bool _paper)
    {
        if (_paper)
        {
            p_unedited.SetPixel(_x, 23 - _y, palette[_color - 1]);
        }else
        {
            i_unedited.SetPixel(_x, 23 - _y, palette[_color - 1]);
        }
    }

    public static void end()
    {
        p_attribute.Apply();
        i_attribute.Apply();
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
