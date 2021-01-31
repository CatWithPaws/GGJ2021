using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSortingLayer : MonoBehaviour
{
	public SpriteRenderer player;
	public SpriteRenderer mask;
	private void Start()
	{
		player.sortingOrder = 10;
		mask.sortingOrder = 11;
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			mask.sortingOrder = -10;
			player.sortingOrder = -11;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			player.sortingOrder = 10;
			mask.sortingOrder = 11;

		}
	}
}
