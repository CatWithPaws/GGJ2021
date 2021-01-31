using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWizardQuest : MonoBehaviour
{
	[SerializeField] GameObject portal;

	private void OnTriggerStay2D(Collider2D other)
	{
		
		{
			//print(WizardQuestHandler.CanPassWizardQuest);
			if (WizardQuestHandler.CanPassWizardQuest)
			{
				portal.SetActive(false);
			}
		}
	}
}
