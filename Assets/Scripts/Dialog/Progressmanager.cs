using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressmanager : MonoBehaviour
{
    [SerializeField] public Day[] Days;
	[SerializeField] public int TimeIndex = 0;
	Dictionary<int, GameObject> TimeInnDex;
	[SerializeField] GameObject tutorial;
	[SerializeField] GameObject tutorial2;

	void Start()
    {

		TimeInnDex = new Dictionary<int, GameObject>();
		for (int iNdex = 0; iNdex < Days.Length; iNdex++)
        {
			for (int iNDex = 0; iNDex < Days[iNdex].Time.Length; iNDex++)
            {
				TimeInnDex.Add(TimeIndex, Days[iNdex].Time[iNDex]);
				TimeIndex++;
				
			}
        }
	}

	[System.Serializable]
	public class Day
	{

		[SerializeField] public GameObject[] Time;
		//[SerializeField] public GameObject film;

		//defult value
		Day()
		{
			
		}
	};

	public void start()
    {
		if (staticDataHolder.finishedtutorial)
        {
			if (staticDataHolder.customerValue == 1)
			{
				TimeInnDex[staticDataHolder.currentIndex].SetActive(true);
				TimeInnDex[staticDataHolder.currentIndex].GetComponent<TextField>().Satisfied = false;
				staticDataHolder.customerValue = 0;
			}
			else
			{
				TimeInnDex[staticDataHolder.currentIndex].SetActive(true);
				TimeInnDex[staticDataHolder.currentIndex].GetComponent<TextField>().Satisfied = true;
			}
		}
		else if (!staticDataHolder.finishedtutorial&&staticDataHolder.currentTime==0)
        {
			tutorial.SetActive(true);
		}
		else if (!staticDataHolder.finishedtutorial && staticDataHolder.currentTime == 2)
        {
			tutorial2.SetActive(true);
        }
    }

	public void End()
    {
		if (staticDataHolder.finishedtutorial)
        {
			Debug.Log("End");
			//print(staticDataHolder.currentTime);
			TimeInnDex[staticDataHolder.currentIndex].SetActive(false);
			staticDataHolder.currentIndex++;
			if (staticDataHolder.currentTime == 0)
			{
				GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(3);
				staticDataHolder.currentTime++;
			}//sometimes staticDataHolder.currentTime == 3 idk why (prob from redroom exit button spam)
			else
			{
				GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(4);
			}
		}
		else if (!staticDataHolder.finishedtutorial && staticDataHolder.currentTime == 0)
        {
			GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(3);
			staticDataHolder.currentTime++;
		}
		else
        {
			GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(4);
		}

    }
}
