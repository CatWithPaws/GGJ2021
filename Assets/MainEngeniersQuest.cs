using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEngeniersQuest : MonoBehaviour
{
    public static GameType currentGame;
    

    private void Awake()
    {
        WorldBroadcast.GameEngWin.Subscribe(OnMinigameWin);
    }

    private void OnDestroy()
    {
        WorldBroadcast.GameEngWin.Unsubscribe(OnMinigameWin);
    }

    private void OnMinigameWin(GameObject o)
    {
        switch (currentGame)
        {
            case GameType.Snowman:
                WorldBroadcast.SnowmanEventActivate.Publish(gameObject);
                break;
            case GameType.Generator:
                WorldBroadcast.GeneratorEventActivate.Publish(gameObject);
                break;
            case GameType.Music:
                WorldBroadcast.MusicEventActivate.Publish(gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}


public enum GameType
{
    Snowman,
    Generator,
    Music
}