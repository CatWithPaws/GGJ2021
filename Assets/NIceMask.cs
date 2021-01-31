using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NIceMask : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			GlobalVars.i.FadeIn("Credits");
		}
	}
}
