using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMask : MonoBehaviour
{
	[SerializeField] MaskType mask;
	private void OnTriggerStay2D(Collider2D collision)
	{
		

		if (Input.GetKeyDown(KeyCode.E))
		{
			GlobalVars.i.currentMask = mask;
			GlobalVars.i.OnWizardQuestDone();
		}
	}
}
