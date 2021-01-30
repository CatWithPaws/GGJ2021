using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSortingLayer : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("NeedToCnahngeSortingLayer"))
		{
			transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		}
	}
}
