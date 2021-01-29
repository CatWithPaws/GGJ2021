using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
	int ID = 0;

	public void Do()
	{
		GlobalVars.Instance.PickIngridient(ID);
		Player.Instance.PickIngridient(ID);
		gameObject.SetActive(false);
	}
}
