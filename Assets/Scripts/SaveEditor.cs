using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

#if (UNITY_EDITOR) 

public class SaveEditor : EditorWindow
{
    string buttontext;
    string jsonstring;
    string string1 = "String1";
    int selected = 0;
    string[] Saves = new string[]
    {
        "save1","save2","save3"
    };
    [MenuItem("Examples/Editor GUILayout Popup usage")]
    //selected = EditorGUILayout.Popup("Label", selected, options); 

    [MenuItem("Window/SaveEditor")]
    public static void ShowWindow()
    {
        GetWindow<SaveEditor>("SaveEditor");
    }


    void OnGUI()
    {
        EditorStyles.textField.wordWrap = true;
        GUILayout.Label("Save Editor MK.I", EditorStyles.boldLabel);

        selected = EditorGUILayout.Popup(selected, Saves);
        SaveSelected();


        //string1 = EditorGUILayout.TextField("Name", string1);
        if (GUILayout.Button(buttontext))
        {
            if (buttontext == "create")
            {
                SaveData save = new SaveData(0, 1, 0, selected+1);
                staticDataHolder.Save_ = save;
                save.SaveIntoJson(save);
                Debug.Log("create " + "Savedata_" + selected+1);
            }
            else if (buttontext == "Save")
            {
                string jsonstring = string1;
                SaveData save = JsonUtility.FromJson<SaveData>(jsonstring);
                staticDataHolder.Save_ = save;
                Debug.Log("load " + "Savedata_" + selected+1);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SaveSelected()
    {
        switch (selected)
        {
            case 0:
                if (System.IO.File.Exists(Application.persistentDataPath + "/Savedata_" + (selected + 1) + ".json"))
                {
                    jsonstring = File.ReadAllText(Application.persistentDataPath + "/Savedata_1.json");
                    string1 = jsonstring;
                    string1 = EditorGUILayout.TextField("SaveData1", string1, GUILayout.Height(200));
                    buttontext = "Save";
                }
                else
                {
                    buttontext = "create";
                }

                break;
            case 1:
                if (System.IO.File.Exists(Application.persistentDataPath + "/Savedata_" + (selected + 1) + ".json"))
                {
                    jsonstring = File.ReadAllText(Application.persistentDataPath + "/Savedata_2.json");
                    string1 = jsonstring;
                    string1 = EditorGUILayout.TextField("SaveData2", string1, GUILayout.Height(200));
                }
                else
                {
                    buttontext = "create";
                }
                break;
            case 2:
                if (System.IO.File.Exists(Application.persistentDataPath + "/Savedata_" + (selected + 1) + ".json"))
                {
                    jsonstring = File.ReadAllText(Application.persistentDataPath + "/Savedata_3.json");
                    string1 = jsonstring;
                    string1 = EditorGUILayout.TextField("SaveData3", string1, GUILayout.Height(200));
                }
                else
                {
                    buttontext = "create";
                }
                break;

            default:
                Debug.LogError("Unrecognized Option");
                break;
        }

    }
    
}


#endif
