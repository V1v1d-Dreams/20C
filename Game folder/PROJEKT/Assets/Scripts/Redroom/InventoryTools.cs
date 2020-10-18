using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTools : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public bool IsUp = false;
    [SerializeField]GameObject PhotoInv;
    RaycastHit2D[] raycast;
    [SerializeField]Camera cam;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
            for (int i = 0; i < raycast.Length; i++)
            {
                if (raycast[i].collider.gameObject.name == gameObject.name)
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
                        PhotoInv.GetComponent<Inventory>().Down();
                    }

                    break;
                }
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Up()
    {
        if (!IsUp)
        {
            transform.position = new Vector3(transform.position.x, -0.1f, transform.position.z);
            GetComponent<SpriteRenderer>().sortingOrder += 3;
            IsUp = true;
        }
    }

    public void Down()
    {
        if (IsUp)
        {
            transform.position = new Vector3(transform.position.x, -4.04f, transform.position.z);
            GetComponent<SpriteRenderer>().sortingOrder -= 3;
            IsUp = false;
        }
    }
}
