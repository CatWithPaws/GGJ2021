using System;
using UnityEngine;

public class BulletInfoBehaviour : MonoBehaviour
{
	public TechMinigame minigame;

	public void DestroyThis()
    {
       Destroy(gameObject);
		minigame.didLoose = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Line")) return;
        print("HitPoint");
        FindObjectOfType<TechMinigame>().points++;
        Destroy(gameObject);
    }
}

public enum BulletType
{
    Standard,
    Destroyer
}