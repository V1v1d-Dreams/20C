using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public bool IsUp = false;

    void Start()
    {
        
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseUp()
    {
        if (IsUp)
        {
            transform.position = new Vector2(transform.position.x, -10.3f);
            IsUp = false;
            
        }
        else
        {
            transform.position = new Vector2(transform.position.x, -4.11f);
            IsUp = true;
        }
        
    }
}
