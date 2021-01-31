using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class FinalMechanicDoinn : CanBeTriggeredByPlayer
{

    private DialogueInvoker di;
    void Start()
    {
        di = GetComponent<DialogueInvoker>();
    }

    void Update()
    {
        if (isPlayer && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(Do());
        }
    }

    private IEnumerator Do()
    {
        yield return new WaitForSeconds(5f);
        
    }
}