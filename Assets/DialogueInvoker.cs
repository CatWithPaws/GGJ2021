using UnityEngine;

public class DialogueInvoker : MonoBehaviour
{
    [SerializeField]private Dialogue[] dialogues;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider && other.collider.CompareTag("Players") && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var d in dialogues)
            {
                DialogueManager.AddDialogue(d);
            }
            Destroy(gameObject);
            
        }
    }
}
