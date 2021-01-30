using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars i;

	public Image[] QuestItems;

	
	
	private void Awake()
	{
		i = this;
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
