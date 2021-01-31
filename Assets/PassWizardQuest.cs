using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWizardQuest : MonoBehaviour
{
	[SerializeField] GameObject portal;
	[SerializeField] GameObject[] particles;
	[SerializeField] GameObject Mask;
	private void OnTriggerStay2D(Collider2D other)
	{
		
		{
			//print(WizardQuestHandler.CanPassWizardQuest);
			if (WizardQuestHandler.CanPassWizardQuest)
			{
				foreach(var a in particles)
				{
					a.SetActive(false);
				}
				portal.SetActive(false);
				Mask.SetActive(true);
			}
		}
	}
}
