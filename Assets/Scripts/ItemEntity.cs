using UnityEngine;

public class ItemEntity : CanBeTriggeredByPlayer
{
    
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            WorldBroadcast.ItemCollected.Publish(GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}
