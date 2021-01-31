using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWizardQuest : MonoBehaviour
{
    void Start()
    {
		if (GlobalVars.i.isPassingWizardQuest) Destroy(gameObject); 
		GlobalVars.i.isPassingWizardQuest = true;
		
	}
	
}
