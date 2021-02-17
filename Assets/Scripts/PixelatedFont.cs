using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PixelatedFont : MonoBehaviour
{
        void Start()
        {
            GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
        }
}

//To use pixelated font script
//1.Import custom font(even if this will be the same original) and set font size to 300 :)
//2.Set it's "Rendering mode" to "Hinted Raster"
//3.Add the following script to this text element: