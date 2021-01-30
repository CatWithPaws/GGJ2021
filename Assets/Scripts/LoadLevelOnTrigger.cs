using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class LoadLevelOnTrigger : MonoBehaviour
{
	
	[SerializeField] private string sceneToLoad;
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		print(other.collider.name);
		if (other.collider && other.collider.CompareTag("Players"))
		{
			print("Collided with levelloader");
			StartCoroutine(GlobalVars.i.FadeIn(sceneToLoad));
		}
	}
}
