using System;
using UnityEngine;

public class BulletInfoBehaviour : MonoBehaviour
{
	public TechMinigame minigame;

	public void DestroyThis()
    {
		minigame.didLoose = true;
		Destroy(gameObject);
	
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        /*if (!other.CompareTag("Line")) return;
        
        FindObjectOfType<TechMinigame>().points++;
        print("HitPoint");
        Destroy(gameObject);*/
    }
}

public enum BulletType
{
    Standard,
    Destroyer
}