using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightInMemories : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (GlobalVars.i.loreStage == 2) return;
		StartCoroutine(MoveLight());
    }

	IEnumerator MoveLight()
	{
		float timer = 0f;
		while (timer < 2f)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0;
		while (timer < 2f)
		{
			timer += Time.deltaTime;
			transform.Translate(-4f * Time.deltaTime, 0, 0);
			yield return new WaitForEndOfFrame();
		}
		GlobalVars.i.FadeIn("House");
	}
}
