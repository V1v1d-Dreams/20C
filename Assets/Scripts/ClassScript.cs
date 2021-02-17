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



