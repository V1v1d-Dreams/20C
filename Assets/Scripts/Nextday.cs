using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextday : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI Day;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDay(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeDay(float waitTime)
    {
        if (staticDataHolder.finishedtutorial)
        {
            Day.text = "day " + (staticDataHolder.daynumber).ToString();
            yield return new WaitForSeconds(waitTime);
            Day.text = "day " + (staticDataHolder.daynumber + 1).ToString();
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("levelLoader").GetComponent<Levelloader>().newday();
        }
        else
        {
            Day.text = "day " + (0).ToString();
            yield return new WaitForSeconds(waitTime);
            Day.text = "day " + (1).ToString();
            yield return new WaitForSeconds(waitTime);
            staticDataHolder.finishedtutorial = true;
            staticDataHolder.currentTime = 0;
            GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(2);
        }

    }
}
