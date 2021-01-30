using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoadDialog : MonoBehaviour
{
	[SerializeField] Transform dialogPosition;
	bool isPlayedOnce = false;
	[SerializeField] string dialogName,cyclicDialog;

    
	void Do()
	{
		PlayDialogue.Instance.gameObject.SetActive(true);
		if(!isPlayedOnce) PlayDialogue.Instance.StartDialog(dialogName,dialogPosition);
		else PlayDialogue.Instance.StartDialog(cyclicDialog, dialogPosition);
		isPlayedOnce = true;
	}
}
