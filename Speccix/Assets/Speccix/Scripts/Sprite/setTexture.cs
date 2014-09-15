using UnityEngine;
using System.Collections;

public class setTexture : MonoBehaviour {

	
	void Start () 
    {
	    if (b_attribute_clash)
        {
            this.renderer.material.mainTexture = attributeClash.b_attribute_clash;
        }

        if (sprite)
        {
            this.renderer.material.SetTexture("_BackGround", attributeClash.b_attribute_clash);
        }
	}

    public bool b_attribute_clash = false;
    public bool sprite = false;
  
}
