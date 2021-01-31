using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanGunChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WorldBroadcast.SnowmanEventActivate.Subscribe(o =>
        {
            GetComponentInChildren<GameEngeniersTrigger>().enabled = false;
            GetComponent<Animator>().enabled = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
