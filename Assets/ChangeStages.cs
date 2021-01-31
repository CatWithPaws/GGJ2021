using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStages : MonoBehaviour
{
	private void Start()
	{
		GlobalVars.i.OnWizardQuestDone += ChangeStage;
	}

	private void ChangeStage()
	{
		DialogueInvoker dialogueInvoker = gameObject.GetComponent<DialogueInvoker>();

		dialogueInvoker.stage = 1;
	}
}
