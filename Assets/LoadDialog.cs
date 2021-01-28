using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoadDialog : MonoBehaviour
{
	[SerializeField] Transform dialogPosition;
	[SerializeField] RectTransform dialogRectTransform;

	bool isPlayedOnce = false;
    // Update is called once per frame
    void Update()
    {
		Vector3 dialogViewPortPosition = Camera.main.WorldToViewportPoint(dialogPosition.position);

		dialogRectTransform.position = Camera.main.ViewportToScreenPoint(dialogViewPortPosition);

	}
	void Do()
	{
		print("zzzzzz");
		PlayDialogue.Instance.gameObject.SetActive(true);
		if(!isPlayedOnce) PlayDialogue.Instance.StartDialog("001");
		else PlayDialogue.Instance.StartDialog("002");
		isPlayedOnce = true;

	}
}
