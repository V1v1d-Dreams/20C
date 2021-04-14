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
    private static GameObject TodaysFilm2;
    private static GameObject TodaysFilm3;

    private static SaveData save_;
    private static int MechineLv = 1;
    private static int HangerLv = 1; 
    private static int PaperNumber = 10; //number of paper
    private static int Chemlv = 1; //chemical
    private static bool Tray = false; //6 Trays
    private static int Money = 100;  //money
    private static int LumpSum = 0;
    private static bool FinishedTutorial = false;

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

    public static GameObject Todaysfilm2
    {
        get
        {
            return TodaysFilm2;
        }
        set
        {
            TodaysFilm2 = value;
        }
    }

    public static GameObject Todaysfilm3
    {
        get
        {
            return TodaysFilm3;
        }
        set
        {
            TodaysFilm3 = value;
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

    public static int hangerLv
    {
        get
        {
            return HangerLv;
        }
        set
        {
            HangerLv = value;
        }
    }

    public static bool tray
    {
        get
        {
            return Tray;
        }
        set
        {
            Tray = value;
        }
    }

    public static int chemlv
    {
        get
        {
            return Chemlv;
        }
        set
        {
            Chemlv = value;
        }
    }

    public static int papernumber
    {
        get
        {
            return PaperNumber;
        }
        set
        {
            PaperNumber = value;
        }
    }

    public static int money
    {
        get
        {
            return Money;
        }
        set
        {
            Money = value;
        }
    }

    public static bool finishedtutorial
    {
        get
        {
            return FinishedTutorial;
        }
        set
        {
            FinishedTutorial = value;
        }
    }

    public static int lumpsum
    {
        get
        {
            return LumpSum;
        }
        set
        {
            LumpSum = value;
        }
    }
}
