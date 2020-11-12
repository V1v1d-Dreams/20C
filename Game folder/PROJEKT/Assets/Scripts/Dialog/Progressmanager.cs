using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressmanager : MonoBehaviour
{
    [SerializeField] public Day[] Days;
	[SerializeField] public int TimeIndex = 0;
	Dictionary<int, GameObject> TimeInnDex;

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
		TimeInnDex[staticDataHolder.currentIndex].SetActive(true);
    }

	public void End()
    {
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
}
