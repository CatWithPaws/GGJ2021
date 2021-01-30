
using UnityEngine;

public class TechMinigame : MonoBehaviour
{
    public GameObject platformPrefab;
    void Start()
    {
        WorldBroadcast.CollectionGameEnded.Publish(gameObject);
    }
}
