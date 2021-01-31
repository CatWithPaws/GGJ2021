using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NIceMask : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			WorldBroadcast.MaskChanged.Publish(MaskType.Self);

		}
	}

	IEnumerator LoadCredits()
	{
		yield return new WaitForSeconds(3);
		StartCoroutine(GlobalVars.i.FadeIn("Credits"));
	}

}
