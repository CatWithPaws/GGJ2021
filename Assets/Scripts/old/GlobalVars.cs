using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{
	public delegate void VoidFunc();

	public static GlobalVars i;

	public Image[] QuestItems;

	public Image[] Faders;

	public Player player;

	public bool needToFadeOut;

	public AudioSource OneShootEffectAudio,OneShootMusic,BackroundMusic;

	public  bool isPassingHuntersQuest, isPassingWizardQuest;
	public bool canWizard = true, canHunters = true;
	public int loreStage = 0;

	

	public VoidFunc OnCanPassHuntersMiniGame;
	public VoidFunc OnCanPassWizardMiniGame;
	public VoidFunc OnWizardQuestDone;
	public VoidFunc OnHuntersQuestDone;
	public AudioClip clip;
	public MaskType currentMask = MaskType.Default;

	private void Start()
	{
		i = this;
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += FadeOut;
		WorldBroadcast.ItemCollected.Subscribe(CheckIsQuestCompleted);
		PlayBackgroundMusic(clip);
		OnHuntersQuestDone += DoneHunters;
		OnWizardQuestDone += DoneWizards;
		
	}

	private void Update()
	{
		//print(isPassingWizardQuest);
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
				image.color += new Color(0, 0, 0, Time.deltaTime);
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
				image.color -= new Color(0, 0, 0, Time.deltaTime);
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
		OneShootEffectAudio.Stop();
		OneShootEffectAudio.PlayOneShot(clip);
	}

	public void PlayOneShotMusic(AudioClip clip)
	{
		OneShootMusic.Stop();
		OneShootMusic.clip = clip;
		OneShootMusic.Play();
	}

	public void PlayBackgroundMusic(AudioClip clip)
	{
		print("asdadadasd");
		GlobalVars.i.BackroundMusic.Stop();
		BackroundMusic.clip = clip;
		BackroundMusic.Play();
	}

	public  void CheckIsQuestCompleted(Sprite asdasd)
	{
		if (isPassingHuntersQuest)
		{
			if (InventoryUI.itemList.Count == 4)
			{
				OnCanPassHuntersMiniGame();
			}
		}
		else if (isPassingWizardQuest)
		{
			if (InventoryUI.itemList.Count == 5)
			{
				print("Wizard");
				OnCanPassWizardMiniGame();
			}
		}
	}

	public void DoneHunters()
	{
		isPassingHuntersQuest = false;
		WorldBroadcast.CollectionGameEnded.Publish(gameObject);
		loreStage++;
		canHunters = false;
		currentMask = MaskType.Tiger;
		WorldBroadcast.MaskChanged.Publish(MaskType.Tiger);
		print("Basdadasd");
		StartCoroutine(FadeIn("Memorr"));
		
	}

	public void DoneWizards()
	{
		isPassingWizardQuest = false;
		canWizard = false;
		WorldBroadcast.CollectionGameEnded.Publish(gameObject);
		loreStage++;
		currentMask = MaskType.Owl;
		WorldBroadcast.MaskChanged.Publish(MaskType.Owl);
		StartCoroutine(FadeIn("Memorr"));
	}

	public void DoneTech()
	{
		loreStage++;
		currentMask = MaskType.Monkey;
		WorldBroadcast.MaskChanged.Publish(MaskType.Monkey);
		StartCoroutine(FadeIn("Memorr"));
		
	}
}
