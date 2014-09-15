using UnityEngine;
using System.Collections;

public class sprite : MonoBehaviour {

	
	void Start () 
    {
        tr = this.GetComponent<Transform>();
        width = (int)(tr.localScale.x / 8);
        height = (int)(tr.localScale.y / 8);
	}

    Vector2 screenPos;
    Transform tr;
    public int single_color = -1;

    int width = 0;
    int height = 0;
    public bool debug = false;

	void Update () 
    {
         //Get the top left position of the quad in screen space
        screenPos.x = (int)(tr.position.x + 128 - Mathf.Abs(tr.localScale.x) / 2);
        screenPos.y = (int)(192 - tr.position.y - 96 - tr.localScale.y / 2);
        
        if (single_color == -1)
        {
            return;
        }

        for (int x = 0; x<width; x++)
        {
            for (int y = 0; y<height; y++)
            {
                attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8), single_color);

                if (screenPos.x % 8 != 0)
                {
                    attributeClash.draw((int)((x * 8 + screenPos.x) / 8) + 1, (int)((y * 8 + screenPos.y) / 8), single_color);
                }

                if (screenPos.y % 8 != 0)
                {
                    attributeClash.draw((int)((x * 8 + screenPos.x) / 8), (int)((y * 8 + screenPos.y) / 8)+1, single_color);
                }

                if(screenPos.y % 8 != 0 && screenPos.x % 8 != 0)
                {
                    attributeClash.draw((int)((x * 8 + screenPos.x) / 8) +1, (int)((y * 8 + screenPos.y) / 8) + 1, single_color);
                }

            }
        }        
	}

    void LateUpdate()
    {        
        this.renderer.material.SetTexture("_BackGround", attributeClash.b_attribute_clash);
    }

    void OnGUI()
    {
        if (debug == false)
        {
            return;
        } 

        GUI.Label(new Rect(0, 0, 1000, 1000), "Sprite pos: " + tr.position + "\n2D pos: " + screenPos + "\nWidth/height: " + width + "/" + height);
    }
}
