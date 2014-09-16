using UnityEngine;
using System.Collections;

public class sprite : MonoBehaviour
{


    void Start()
    {
        tr = this.GetComponent<Transform>();
        width = (int)(tr.localScale.x / 8);
        height = (int)(tr.localScale.y / 8);
    }

    Vector2 screenPos;
    Transform tr;
    public int paper_color = 0;
    public int ink_color = 0;

    int width = 0;
    int height = 0;


    void Update()
    {
        //Get the top left position of the quad in screen space
        screenPos.x = (int)(tr.position.x + 128 - Mathf.Abs(tr.localScale.x) / 2);
        screenPos.y = (int)(192 - tr.position.y - 96 - tr.localScale.y / 2);

        if (paper_color >= 1)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8), paper_color, true);

                    if (screenPos.x % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8) + 1, (int)((y * 8 + screenPos.y) / 8), paper_color, true);
                    }

                    if (screenPos.y % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8) + 1, paper_color, true);
                    }

                    if (screenPos.y % 8 != 0 && screenPos.x % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8) + 1, (int)((y * 8 + screenPos.y) / 8) + 1, paper_color, true);
                    }
                }
            }
        }

        if (ink_color >= 1)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8), ink_color, false);

                    if (screenPos.x % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8) + 1, (int)((y * 8 + screenPos.y) / 8), ink_color, false);
                    }

                    if (screenPos.y % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8) + 1, ink_color, false);
                    }

                    if (screenPos.y % 8 != 0 && screenPos.x % 8 != 0)
                    {
                        attributeClash.draw((int)((x * 8 + screenPos.x) / 8) + 1, (int)((y * 8 + screenPos.y) / 8) + 1, ink_color, false);
                    }
                }
            }
        }

        
    }

    void LateUpdate()
    {
        this.renderer.material.SetTexture("_Paper", attributeClash.p_attribute);
        this.renderer.material.SetTexture("_Ink", attributeClash.i_attribute);
    }
}
