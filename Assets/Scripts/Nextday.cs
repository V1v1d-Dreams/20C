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
            if (staticDataHolder.daynumber + 1 != 12)
            {
                Day.text = "day " + (staticDataHolder.daynumber).ToString();
                yield return new WaitForSeconds(waitTime);
                Day.text = "day " + (staticDataHolder.daynumber + 1).ToString();
                staticDataHolder.chemlv = 1;
                yield return new WaitForSeconds(waitTime);
                GameObject.Find("levelLoader").GetComponent<Levelloader>().newday();

                staticDataHolder.Save_.CurrentTime = staticDataHolder.currentTime;
                staticDataHolder.Save_.Daynumber = staticDataHolder.daynumber;

                staticDataHolder.Save_.Day = staticDataHolder.daynumber + 1;
                staticDataHolder.Save_.conversationNo = staticDataHolder.currentIndex;

                staticDataHolder.Save_.MechineLv = staticDataHolder.mechinelv;
                staticDataHolder.Save_.HangerLv = staticDataHolder.hangerLv;
                staticDataHolder.Save_.PaperNumber = staticDataHolder.papernumber;
                staticDataHolder.Save_.Chemlv = staticDataHolder.chemlv;
                staticDataHolder.Save_.Tray = staticDataHolder.tray;
                staticDataHolder.Save_.money = staticDataHolder.money;
                staticDataHolder.Save_.LumpSum = staticDataHolder.lumpsum;
                staticDataHolder.Save_.FinishedTutorial = staticDataHolder.finishedtutorial;

                staticDataHolder.Save_.SaveIntoJson(staticDataHolder.Save_);
            }
            else
            {
                Day.text = "The End";
                yield return new WaitForSeconds(waitTime*1.5f);
                GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(0);
            }
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
