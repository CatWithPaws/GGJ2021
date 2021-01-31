using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentGame : MonoBehaviour
{
    public GameType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        MainEngeniersQuest.currentGame = type;
    }
}
