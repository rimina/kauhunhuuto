using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomScript : MonoBehaviour {

	private int beastSightCount_ = 0;

	public void changescene(string scenename)
	{
		SceneManager.LoadScene(scenename);
	}

	public void BeastSeen(){
		++beastSightCount_;
		Debug.Log("peto nähty:" + beastSightCount_);

		if(beastSightCount_ >= 3){
			Debug.Log("Hävisit pelin");
			beastSightCount_ = 0;
			Application.Quit();
		}
	}

	public void Update(){
		if(Input.GetKeyDown("escape"))
		{
			Debug.Log("You escaped");
			Application.Quit();

		}
		
	}
	
	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}