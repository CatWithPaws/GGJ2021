
using UnityEngine;

public class MainMechanicStates : MonoBehaviour
{
    private int points;
    void Start()
    {
        WorldBroadcast.GameEngWin.Subscribe(OnGameEngWin);
    }

    private void OnGameEngWin(GameObject o)
    {
        points++;
        if (points >= 2) GetComponent<DialogueInvoker>().stage = 1;
    }
}
