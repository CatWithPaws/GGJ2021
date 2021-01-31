using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHuntsQuest : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GlobalVars.i.isPassingHuntersQuest = true;
	}
}
