using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardQuestHandler : MonoBehaviour
{
	public static bool CanPassWizardQuest;

	private void Start()
	{
		GlobalVars.i.OnCanPassWizardMiniGame += SetCanPassWizardQuest;
	}

	void SetCanPassWizardQuest()
	{
		CanPassWizardQuest = true;
	}
}
