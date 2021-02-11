﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticDataHolder : MonoBehaviour
{
    private static int CurrentIndex = 0;
    private static int CurrentTime = 0;
    private static int Daynumber = 0;
    private static float CustomerValue = 0;
    private static GameObject TodaysFilm;
    private static SaveData save_;
    private static int MechineLv = 1;

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

    public static int daynumber
    {
        get
        {
            return Daynumber;
        }
        set
        {
            Daynumber = value;
        }
    }

    public static float customerValue
    {
        get
        {
            return CustomerValue;
        }
        set
        {
            CustomerValue = value;
        }
    }

    public static GameObject Todaysfilm
    {
        get
        {
            return TodaysFilm;
        }
        set
        {
            TodaysFilm = value;
        }
    }

    public static SaveData Save_
    {
        get
        {
            return save_;
        }
        set
        {
            save_ = value;
        }
    }

    public static int mechinelv
    {
        get
        {
            return MechineLv;
        }
        set
        {
            MechineLv = value;
        }
    }
}
