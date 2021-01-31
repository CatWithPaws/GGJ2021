using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHuntersMusic : MonoBehaviour
{
	public AudioClip clip;
    void Start()
    {
		GlobalVars.i.PlayBackgroundMusic(clip);
    }
}
