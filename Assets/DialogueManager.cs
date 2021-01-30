using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static Queue<Dialogue> _queue;

    public GameObject dialogueScreenPrefab;
    
    void Start()
    {
        _queue = new Queue<Dialogue>();
        StartCoroutine(DialogueTracker());
    }

    private IEnumerator DialogueTracker()
    {
        while (true)
        {
            if (_queue.Count > 0)
            {
                var currentDialogue = _queue.Dequeue();
                var dialogueScreen = Instantiate(dialogueScreenPrefab).GetComponent<DialogueScreen>();
                dialogueScreen.transform.parent = transform;
                dialogueScreen.dialogue = currentDialogue;
                var cam = Camera.main;
                while (!dialogueScreen.isFinished)
                {
                    dialogueScreen.transform.position = 
                        cam.WorldToScreenPoint(currentDialogue.obj.transform.position 
                                               + Vector3.up * currentDialogue.yOffset);
                    yield return null;
                }
                Destroy(dialogueScreen);
            }
            yield return null;
        }
    }

    public static void AddDialogue(Dialogue dialogue)
    {
        _queue.Enqueue(dialogue);
    }
}

[Serializable]
public class Dialogue
{
    public GameObject obj;
    public string message;
    public float yOffset;
}