using UnityEngine;
using System.Collections;

public class Laake : MonoBehaviour{
    public GameObject gameObj;

    private bool laake_ = false;
    [SerializeField] Puhekupla kupla_;

    void Awake(){
    	laake_ = GameState.Instance.getLaakeLoydetty();
        if(laake_){
            gameObj.SetActive(false);
        }
    }

    void OnMouseDown(){
    	if(!laake_){
    		laake_ = true;
    		GameState.Instance.setLaakeLoydetty(laake_);
            kupla_.show();
            gameObj.SetActive(false);
    	}
    }
}