using System;
using UnityEngine;

public class DialogueInvoker : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;

    private bool isPlayer;


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

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var d in dialogues)
            {
                DialogueManager.AddDialogue(d);
            }
            //Destroy(gameObject);
            isPlayer = false;
        }
    }
}
