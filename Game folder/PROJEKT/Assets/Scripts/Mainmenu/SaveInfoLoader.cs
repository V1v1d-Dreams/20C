using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveInfoLoader : MonoBehaviour
{
    [SerializeField] int slotnumber;

    void Awake()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/Savedata_" + slotnumber + ".json"))
        {
            string jsonstring = File.ReadAllText(Application.persistentDataPath + "/Savedata_" + slotnumber + ".json");
            SaveData save = JsonUtility.FromJson<SaveData>(jsonstring);
            this.GetComponent<UnityEngine.UI.Text>().text = "day : " + save.Day + "\n" +
                                                            "money : " + save.money;
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "new game";
        }
    }

}
