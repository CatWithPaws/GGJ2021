using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightInMemories : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(MoveLight());
    }

	IEnumerator MoveLight()
	{

		if (GlobalVars.i.loreStage != 3)
		{
			float timer = 0f;
			while (timer < 3f)
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
			StartCoroutine(GlobalVars.i.FadeIn("House"));
		}
	}
}
