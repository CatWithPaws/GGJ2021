using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    void Start()
    {
        WorldBroadcast.GeneratorEventActivate.Subscribe(o =>
        {
            GetComponent<DialogueInvoker>().stage = 1;
        });
    }

    void Update()
    {
        
    }
}
