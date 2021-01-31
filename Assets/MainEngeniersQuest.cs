using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
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
                    StartCoroutine(Enable(l.gameObject.GetComponent<Light2D>()));
                }

                StartCoroutine(CameraClick());
                break;
            case GameType.Music:
                WorldBroadcast.MusicEventActivate.Publish(gameObject);
                GlobalVars.i.PlayBackgroundMusic(newbg);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator Enable(Light2D ob)
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        ob.enabled = true;
    }

    private IEnumerator CameraClick()
    {
        var cam = FindObjectOfType<CinemachineVirtualCamera>();
        var startSize = cam.m_Lens.OrthographicSize;
        for (float i = 0f; i < 9; i+= 0.05f)
        {
            cam.m_Lens.OrthographicSize = startSize + i;
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        for (float i = 9f; i > 0; i-= 0.05f)
        {
            cam.m_Lens.OrthographicSize = startSize + i;
            yield return null;
        }

        cam.m_Lens.OrthographicSize = startSize;
    }
    
}


public enum GameType
{
    Snowman,
    Generator,
    Music
}