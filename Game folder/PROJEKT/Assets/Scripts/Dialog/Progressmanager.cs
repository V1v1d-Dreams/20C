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
		if (TimeInnDex[staticDataHolder.currentIndex] = null)
		{
			GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(5);
		}
		else
		{
			TimeInnDex[staticDataHolder.currentIndex].SetActive(true);
		}
    }

	public void End()
    {
		TimeInnDex[staticDataHolder.currentIndex].SetActive(false);
		staticDataHolder.currentIndex++;
		if (staticDataHolder.currentTime == 0)
        {
			GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(3);
			staticDataHolder.currentTime++;
        }
		if (staticDataHolder.currentTime == 2)
        {
			GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(4);
		}

    }
}
