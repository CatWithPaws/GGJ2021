using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerRight : MonoBehaviour
{
	// Start is called before the first frame update

	Transform[] SpawnPoint;
	public AudioClip clip;
	void Start()
    {
		transform.position = SpawnPoint[GlobalVars.i.loreStage].position;
		GlobalVars.i.PlayBackgroundMusic(clip);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(250, 0);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
    }
}
