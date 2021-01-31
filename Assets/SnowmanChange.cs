using UnityEngine;

public class SnowmanChange : MonoBehaviour
{
    void Start()
    {
        WorldBroadcast.SnowmanEventActivate.Subscribe(o => GetComponent<DialogueInvoker>().stage = 1);
    }
}
