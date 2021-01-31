using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aasdasdasdad : MonoBehaviour
{
	public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(PlaySong());
    }

	IEnumerator PlaySong()
	{
		yield return new WaitForEndOfFrame();
		
		GlobalVars.i.PlayBackgroundMusic(clip);
	}
	
}
