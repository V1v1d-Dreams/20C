using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
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
            transform.position = new Vector3(transform.position.x, -4.04f, transform.position.z);
            GetComponent<SpriteRenderer>().sortingOrder -= 3;
            IsUp = false;
            
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -0.1f, transform.position.z);
            GetComponent<SpriteRenderer>().sortingOrder += 3;
            IsUp = true;
        }
        
    }
}
