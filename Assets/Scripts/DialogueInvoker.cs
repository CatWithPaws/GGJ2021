using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInvoker : CanBeTriggeredByPlayer
{
    [SerializeField] public int stage;
    [SerializeField] private List<Dialogues> stageDialogues;

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var d in stageDialogues[stage].d)
            {
                DialogueManager.AddDialogue(d);
            }
            isPlayer = false;
        }
    }
}

[Serializable]
public class Dialogues
{
    public Dialogue[] d;
}
