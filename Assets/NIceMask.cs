using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NIceMask : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Players"))
		{
			WorldBroadcast.MaskChanged.Publish(MaskType.Self);
			StartCoroutine(LoadCredits());
		}
	}

	IEnumerator LoadCredits()
	{
		yield return new WaitForSeconds(3);
		StartCoroutine(GlobalVars.i.FadeIn("Credits"));
	}

}
