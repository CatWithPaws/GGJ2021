using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainEngeniersQuest : MonoBehaviour
{
    public static GameType currentGame;

    public AudioClip startbg;
    public AudioClip newbg;
    

    private void Awake()
    {
        GlobalVars.i.PlayBackgroundMusic(startbg);
        WorldBroadcast.GameEngWin.Subscribe(OnMinigameWin);
    }

    private void OnDestroy()
    {
        WorldBroadcast.GameEngWin.Unsubscribe(OnMinigameWin);
    }

    private void OnMinigameWin(GameObject o)
    {
        print(currentGame);
        switch (currentGame)
        {
            case GameType.Snowman:
                WorldBroadcast.SnowmanEventActivate.Publish(gameObject);
                break;
            case GameType.Generator:
                WorldBroadcast.GeneratorEventActivate.Publish(gameObject);
                foreach (var g in FindObjectsOfType<GuzScript>())
                {
                    g.GetComponent<Animator>().enabled = true;
                }

                foreach (var l in FindObjectsOfType<LightScr>())
                {
                    StartCoroutine(Enable(l.gameObject));
                }
                break;
            case GameType.Music:
                WorldBroadcast.MusicEventActivate.Publish(gameObject);
                GlobalVars.i.PlayBackgroundMusic(newbg);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator Enable(GameObject ob)
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 4f));
        ob.SetActive(true);
    }
    
}


public enum GameType
{
    Snowman,
    Generator,
    Music
}