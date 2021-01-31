using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueScreen : MonoBehaviour
{
    public Dialogue dialogue;
    public TextMeshProUGUI text;

    public bool isFinished;

    private void Start()
    {
        FindObjectOfType<Player>().SetControl(false);
    }

    public void OnAppeared()
    {
        print("appeared");
        StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        var textD = dialogue.message;
        print("Started");
        for (int i = 0; i < textD.Length-1; i++)
        {
            print(text);
            text.text = textD.Remove(i);
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.text = textD;
                break;
            }
            yield return new WaitForSeconds(0.025f);
        }

        text.text = textD;

        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;
        }
        print("Dialogue Finished");
        
        FindObjectOfType<Player>().SetControl(true);
        isFinished = true;
    }
    
    
    
}
