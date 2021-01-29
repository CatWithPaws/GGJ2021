using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayDialogue : MonoBehaviour
{
	string[] dialogueQueue;

	public static PlayDialogue Instance;

	[SerializeField] Text dialogueText;
	[SerializeField] RectTransform dialogRectTransform;

	bool isSkipHolding = false;
	bool isInDialog = false;
	bool isSpaceJustPressed;
	private void Awake()
	{
		Instance = this;
		//dialogRectTransform.gameObject.SetActive(false);
	}

	private void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !isSkipHolding)
		{
			isSpaceJustPressed = true;
		}
	}

	public void StartDialog(string number,Transform target)
	{
		if (isInDialog) return;
		isInDialog = true;
		print("Asdasdas");
		gameObject.SetActive(true);
		StartCoroutine(Dialogue(number,target));
	}

	public IEnumerator Dialogue(string dialogueName, Transform target)
	{
		Player.Instance.isInDialog = true;
		Vector3 dialogViewPortPosition = Camera.main.WorldToViewportPoint(target.position);

		dialogRectTransform.position = Camera.main.ViewportToScreenPoint(dialogViewPortPosition);

		string jsonText = (Resources.Load<TextAsset>("Dialogues/dialog" + dialogueName) as TextAsset).text;
		dialogueText.text = "";
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
						yield return new WaitForFixedUpdate();
						if (isSpaceJustPressed && !isSkipHolding)
						{
							isSkipHolding = true;	
							isSpaceJustPressed = false;
							dialogueText.text = dialogueQueue[i];
							isPrintedText = true;
							break;
						}
						
						if(dialogueText.text.Length == replicText.Length || isPrintedText)
						{
							isPrintedText = true;
							while (!Input.GetKeyDown(KeyCode.Space))
							{
								yield return null;
							}
						}
						yield return new WaitForFixedUpdate();
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
		Player.Instance.isInDialog = false;
	}

}

[System.Serializable]
public class data
{
	public string[] text;
}
