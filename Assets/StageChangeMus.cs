using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChangeMus : MonoBehaviour
{
    void Start()
    {
        WorldBroadcast.MusicEventActivate.Subscribe(o =>
        {
            GetComponent<DialogueInvoker>().stage = 1;
        });
    }

    void Update()
    {
        
    }
}
