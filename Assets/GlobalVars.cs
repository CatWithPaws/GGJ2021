using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars Instance;

	public Image[] QuestItems;

	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
		
	}

	public void HideItems()
	{
		foreach (Image image in QuestItems)
		{
			image.color = new Color(1, 1, 1, 0f);
		}
	}

	public void PickIngridient(int ID)
	{
		QuestItems[ID].gameObject.GetComponent<Image>().color = new Color(1,1,1,1f);
	}
}
