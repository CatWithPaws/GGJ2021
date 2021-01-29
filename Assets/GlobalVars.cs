using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars Instance;


	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
