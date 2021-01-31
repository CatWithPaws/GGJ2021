using System;
using UnityEngine;

public class BulletInfoBehaviour : MonoBehaviour
{
    public void DestroyThis()
    {
       Destroy(gameObject); 
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