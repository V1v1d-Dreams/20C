using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticDataHolder : MonoBehaviour
{
    private static int CurrentIndex = 0;
    private static int CurrentTime = 0;

    public static int currentIndex
    {
        get
        {
            return CurrentIndex;
        }
        set
        {
            CurrentIndex = value;
        }
    }

    public static int currentTime
    {
        get
        {
            return CurrentTime;
        }
        set
        {
            CurrentTime = value;
        }
    }
}
