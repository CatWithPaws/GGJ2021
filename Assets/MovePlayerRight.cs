using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerRight : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField] Transform[] SpawnPoint;
	[SerializeField] Transform lightTransform;
	public AudioClip clip;
	void Start()
    {
		Vector3 lightPos = SpawnPoint[GlobalVars.i.loreStage - 1].position;
		transform.position = new Vector3(lightPos.x, lightPos.y, transform.position.z) ;
		
		lightPos.z = lightTransform.position.z;
		lightTransform.position = lightPos;
		GlobalVars.i.PlayBackgroundMusic(clip);
	}

    // Update is called once per frame
    void Update()
    {
		if (GlobalVars.i.loreStage != 3) return;
		if (Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(4, 0);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
    }
}
