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
		GameState.Instance.beastSeen();
	}

	public void Update(){
		if(Input.GetKeyDown("escape"))
		{
			Debug.Log("You escaped");
			Application.Quit();
		}
		if(GameState.Instance.checkEndCondition()){
			Debug.Log("Peli loppui!");
			Application.Quit();
		}
		
	}
	
	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}