using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayDialogue : MonoBehaviour
{
	string[] dialogueQueue;

	public static PlayDialogue Instance;

	[SerializeField] Text dialogueText;

	bool isInDialog = false;

	private void Awake()
	{
		Instance = this;
	}

	public void StartDialog(string number)
	{
		if (isInDialog) return;
		isInDialog = true;
		print("Asdasdas");
		gameObject.SetActive(true);
		StartCoroutine(Dialogue(number));
	}

	public IEnumerator Dialogue(string dialogueName)
	{
		
		string jsonText = (Resources.Load<TextAsset>("Dialogues/dialog" + dialogueName) as TextAsset).text;
		print(jsonText);
		data _Data = JsonUtility.FromJson<data>(jsonText);
		dialogueQueue = _Data.text;
		print(dialogueQueue[0]);
		bool isDialogue = true;
		bool skipDialogue = false;
		bool isPrintedText = false;
		while (isDialogue)
		{
			for(int i = 0;i < dialogueQueue.Length; i++)
			{
				char[] replicText = dialogueQueue[i].ToCharArray();
				if (skipDialogue)
				{
					skipDialogue = false;
					break;
				}
				isPrintedText = false;
				dialogueText.text = "";
				if (!isPrintedText)
				{
					isPrintedText = false;
					for(int j = 0; j < dialogueQueue[i].Length; j++)
					{
						dialogueText.text += replicText[j];
						if (Input.GetKeyDown(KeyCode.Space))
						{
							dialogueText.text = dialogueQueue[i];
							isPrintedText = true;
							break;
						}
						
						if(dialogueText.text.Length == replicText.Length)
						{

							isPrintedText = true;
							while (!Input.GetKeyDown(KeyCode.Space))
							{
								yield return null;
							}
						}
						yield return new WaitForSeconds(0.05f);
					}
				}
				yield return null;
			}
			isDialogue = false;
			yield return null;
		}

		yield return null;

		gameObject.SetActive(false);
		isInDialog = false;
	
	}

}

[System.Serializable]
public class data
{
	public string[] text;
}
