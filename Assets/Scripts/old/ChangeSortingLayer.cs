using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSortingLayer : MonoBehaviour
{
	public SpriteRenderer player;
	public SpriteRenderer mask;
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			mask.sortingOrder = -1;
			player.sortingOrder = -2;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			player.sortingOrder = 1;
			mask.sortingOrder = 2;

		}
	}
}
