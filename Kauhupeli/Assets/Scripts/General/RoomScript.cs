using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Loppu{
    PETOKUOLEMA,
    NEUTRAL,
    BAD,
    GOOD,
    BARON,
    JATKUU
}

public class RoomScript : MonoBehaviour {

	//Vaihtaa scenen
	public void changescene(string scenename){
		SceneManager.LoadScene(scenename);
	}

	//Lopetettiinko
	public void Update(){
		if(Input.GetKeyDown("escape"))
		{
			Debug.Log("You escaped");
			Application.Quit();
		}

		Loppu end = GameState.Instance.checkEndCondition();

		if(end == Loppu.PETOKUOLEMA){
			changescene("Ending_Baron");
		}
		else if(end == Loppu.NEUTRAL){
			changescene("Ending_Neutral");
		}
		else if(end == Loppu.BAD){
			changescene("Ending_Bad");
		}
		else if(end == Loppu.GOOD){
			changescene("Ending_Good");
		}
		else if(end == Loppu.BARON){
			changescene("Ending_Baron");
		}
	}
	
	//Halutaan lopettaa peli painamalla nappia
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}
}