using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToDo : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("Interactive"))
		{
			print("asdasd");
			if (Input.GetKey(KeyCode.E	))
			{
				collision.gameObject.SendMessage("Do");
			}
		}
	}
}
