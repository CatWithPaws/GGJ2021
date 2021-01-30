using UnityEngine;

public class DialogueInvoker : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Players") && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var d in dialogues)
            {
                DialogueManager.AddDialogue(d);
            }
            Destroy(gameObject);
        }
    }
}
