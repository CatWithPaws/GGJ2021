using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoadDialog : MonoBehaviour
{
	[SerializeField] Transform dialogPosition;
	[SerializeField] RectTransform dialogRectTransform;
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
		PlayDialogue.Instance.StartDialog("001");
	}
}
