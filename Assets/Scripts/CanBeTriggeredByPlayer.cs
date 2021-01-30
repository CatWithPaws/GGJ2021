
using UnityEngine;

public class CanBeTriggeredByPlayer : MonoBehaviour
{
    protected bool isPlayer;

    private void Start()
    {
        var cc = gameObject.AddComponent<CircleCollider2D>();
        cc.radius = 1.2f;
        cc.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            isPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            isPlayer = false;
        }
    }
}
