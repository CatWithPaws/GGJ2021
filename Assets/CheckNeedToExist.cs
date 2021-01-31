using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeedToExist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (GlobalVars.i.isPassingHuntersQuest) Destroy(gameObject);
    }

}
