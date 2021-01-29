using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoadDialog : MonoBehaviour
{
	[SerializeField] Transform dialogPosition;
	[SerializeField] RectTransform dialogRectTransform;

	bool isPlayedOnce = false;
    
	void Do()
	{
		print("zzzzzz");
		PlayDialogue.Instance.gameObject.SetActive(true);
		if(!isPlayedOnce) PlayDialogue.Instance.StartDialog("001",dialogPosition);
		else PlayDialogue.Instance.StartDialog("002",transform);
		isPlayedOnce = true;

	}
}
