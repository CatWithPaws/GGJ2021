using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
	[SerializeField] int ID = 0;

	public void Do()
	{
		GlobalVars.i.PickIngridient(ID);
		//Player.Instance.PickIngridient(ID);
		gameObject.SetActive(false);
	}
}