using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHuntsQuest : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!GlobalVars.i.canHunters){
			 Destroy(gameObject);
			return;
		}
		GlobalVars.i.isPassingHuntersQuest = true;
	}
}
