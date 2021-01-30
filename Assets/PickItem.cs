using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PickItem : MonoBehaviour
{
	[SerializeField] int ID = 0;

	public void Do()
	{
		GlobalVars.Instance.PickIngridient(ID);
		Player.Instance.PickIngridient(ID);
		gameObject.SetActive(false);
	}
}
