using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class LoadLevelOnTrigger : MonoBehaviour
{
	
	[SerializeField] private string sceneToLoad;

	private void Awake()
	{
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		print(other.collider.name);
		if (other.collider && other.collider.CompareTag("Players"))
		{
			print("Collided with levelloader");
			StartCoroutine(GlobalVars.i.FadeIn(sceneToLoad));
		}
	}
	//private void OnTriggerEnter2D(Collider2D other)
	//{
	//	print(other.gameObject.name);
	//	if (other.gameObject && other.gameObject.CompareTag("Players"))
	//	{
	//		print("Collided with levelloader");
	//		StartCoroutine(GlobalVars.i.FadeIn(sceneToLoad));
	//	}
	//}
}
