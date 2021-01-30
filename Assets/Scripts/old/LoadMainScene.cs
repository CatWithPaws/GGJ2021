using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMainScene : MonoBehaviour
{
    void Awake()
    {
		SceneManager.LoadScene(1);
    }
	
}
