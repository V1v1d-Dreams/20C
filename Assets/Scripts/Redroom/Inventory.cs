using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public bool IsUp = false;
    [SerializeField]GameObject Toolinv;
    RaycastHit2D[] raycast;
    [SerializeField]Camera cam;

    void Start()
    {

    }

    void Update()
    {
        raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        for (int i = 0; i < raycast.Length; i++)
        {
            if (raycast[i].collider.gameObject.name == gameObject.name)
            {
                Up();
                break;
            }
            else
            {
                Down();
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
        //Up();
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        //Down();

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

    /*
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
                    Toolinv.GetComponent<InventoryTools>().Down();
                }

                break;
            }
        }
     */
}
