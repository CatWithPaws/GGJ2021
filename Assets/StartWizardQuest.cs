using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWizardQuest : MonoBehaviour
{
	public AudioClip clip;

    void Start()
    {
		GlobalVars.i.PlayBackgroundMusic(clip);
		if (GlobalVars.i.isPassingWizardQuest || !GlobalVars.i.canWizard) Destroy(gameObject); 
		GlobalVars.i.isPassingWizardQuest = true;
		
	}
	
}
