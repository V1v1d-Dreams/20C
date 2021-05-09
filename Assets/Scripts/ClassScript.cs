using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    [Serializable]
    public class SaveData
    {
        [SerializeField] private SaveData _saveData;
        public int money;
        public int Day;
        public int conversationNo;
        public int SaveNo;

        public int CurrentTime = 0;
        public int Daynumber = 0;

        public int MechineLv = 1;
        public int HangerLv = 1;
        public int PaperNumber = 10; //number of paper
        public int Chemlv = 1; //chemical
        public bool Tray = false; //6 Trays
        public int Money = 100;  //money
        public int LumpSum = 0;
        public bool FinishedTutorial = false;


    public SaveData(int Money, int day, int ConversationNo, int saveno)
        {
            money = Money;
            Day = day;
            conversationNo = ConversationNo;
            SaveNo = saveno;
        }
        
        public void SaveIntoJson(SaveData save)
        {
            string saveText = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Savedata_" + SaveNo + ".json", saveText);
        }
    }



