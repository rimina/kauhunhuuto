using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {

	
	void Update () {

		if(Input.GetKeyDown("escape"))
		{
			Debug.Log("You escaped");
			Application.Quit();

		}
		
	}
}
