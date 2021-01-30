using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars i;

	public Image[] QuestItems;

	public Image[] Faders;

	public Player player;

	public bool needToFadeOut;

	public AudioSource OneShootEffectAudio,OneShootMusic,BackroundMusic;

	private void Start()
	{
		i = this;
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += FadeOut;
		
	}
	

	public void SetFader(GameObject fader)
	{
		Faders = fader.GetComponents<Image>();
	}

	public void HideItems()
	{
		foreach (Image image in QuestItems)
		{
			image.color = new Color(1, 1, 1, 0f);
		}
	}

	public void PickIngridient(int ID)
	{
		QuestItems[ID].gameObject.GetComponent<Image>().color = new Color(1,1,1,1f);
	}

	public IEnumerator FadeIn(string sceneToLoad)
	{
		while (Faders[0].color.a < 1)
		{
			foreach(var image in Faders)
			{
				image.color += new Color(0, 0, 0, Time.deltaTime/2);
			}
			yield return new WaitForEndOfFrame();
		}
		SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
	}
	public IEnumerator FadeOUT()
	{
		player = FindObjectOfType<Player>() as Player;
		while (Faders[0].color.a > 0)
		{
			foreach (var image in Faders)
			{
				image.color -= new Color(0, 0, 0, Time.deltaTime/2);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	private void FadeOut(Scene scene,LoadSceneMode mode)
	{
		StartCoroutine(FadeOUT());
	}


	public void PlayOneShotEffect(AudioClip clip)
	{
		OneShootEffectAudio.clip = clip;
	}

	public void PlayOneShotMusic(AudioClip clip)
	{
		OneShootMusic.clip = clip;
	}

	public void PlayBackgroundMusic(AudioClip clip)
	{
		BackroundMusic.clip = clip;
	}

}
