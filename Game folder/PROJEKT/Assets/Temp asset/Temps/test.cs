using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public SpriteRenderer sprite;
    float var;
    int num = 0;

    // Start is called before the first frame update

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        print(var);

        if (Input.GetKeyDown(KeyCode.A))
        {
            num += 1;
        }

        if (num == 1 && var <= 0.3f)
        {
            var += 0.005f;
        }
        else if (num == 2 && var > 0.3f && 0.6 >= var)
        {
            var += 0.005f;
        }
        else if (num == 3 && var > 0.6f && 1 >= var)
        {
            var += 0.005f;
        }

        sprite.color = new Color(1f, 1f, 1f, var);
    }
}
