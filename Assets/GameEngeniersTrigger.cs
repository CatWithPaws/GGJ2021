using UnityEngine;

public class GameEngeniersTrigger : CanBeTriggeredByPlayer
{
    public GameObject gamePrefab;
    void Start(){}

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            var o = Instantiate(gamePrefab);
            o.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            isPlayer = false;
        }
    }
}
