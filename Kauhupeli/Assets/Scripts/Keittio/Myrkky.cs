using UnityEngine;
using System.Collections;

public class Myrkky : MonoBehaviour{
    public GameObject gameObj;

    bool myrkytetty_ = false;

    void Awake(){
    	myrkytetty_ = GameState.Instance.getMyrkytys();
    	if(myrkytetty_){
    		gameObj.SetActive(false);
    	}
    }

    void OnMouseDown(){
    	if(!myrkytetty_){
    		myrkytetty_ = true;
    		GameState.Instance.setMyrkytys(myrkytetty_);
    		gameObj.SetActive(false);
    	}
    	else{
    		Debug.Log("why am I still visible?");
    	}
    }
}