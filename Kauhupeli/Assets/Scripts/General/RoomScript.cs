using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomScript : MonoBehaviour {

	private int beastSightCount_ = 0;

	//Vaihtaa scenen
	public void changescene(string scenename){
		SceneManager.LoadScene(scenename);
	}

	//nähtiin random peto
	public void BeastSeen(){
		++beastSightCount_;
		Debug.Log("peto nähty:" + beastSightCount_);
		GameState.Instance.beastSeen();
	}

	//Lopetettiinko
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
	
	//Halutaan lopettaa peli painamalla nappia
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}
}