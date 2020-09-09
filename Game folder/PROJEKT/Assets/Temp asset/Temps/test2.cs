using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    private Animator animator;

    private Vector2 innitialpos;
    private bool locked;

    [SerializeField]
    private Transform Placepos;
    private Vector2 mouseposition;
    private float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()  //X 3.45- 7.83 Y -2.92 2.94
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        animator = gameObject.GetComponent<Animator>();
    }


    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseDrag()
    {
        Cursor.SetCursor(hold, Vector2.zero, CursorMode.ForceSoftware);
        if (!locked)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);
        }
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    void OnMouseUp()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (Mathf.Abs(transform.position.x - Placepos.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - Placepos.position.y) <= 0.5f)
        {
            transform.position = new Vector2(Placepos.position.x, Placepos.position.y);
            locked = true;
            animator.SetTrigger("place");
        }
        else if (transform.position.x > 3.45 && transform.position.x < 7.83 &&
            transform.position.y > -2.92 && transform.position.y < 2.94)
        {
            innitialpos = transform.position;
        }
        else
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
        }
        
        
        /*
        if (Mathf.Abs(transform.position.x - Placepos.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - Placepos.position.y) <= 0.5f)
        {
            transform.position = new Vector2(Placepos.position.x, Placepos.position.y);
            locked = true;
            animator.SetTrigger("place");
        }
        else
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
        }
        */
    }
}
