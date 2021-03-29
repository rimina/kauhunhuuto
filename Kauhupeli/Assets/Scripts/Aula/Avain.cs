using UnityEngine;
using System.Collections;

public class Avain : MonoBehaviour{
    public GameObject gameObj;

    private bool avain_ = false;
    private float timeLeft_ = 2000.0f;
    private float time_ = 0.0f;
    [SerializeField] Puhekupla kupla_;
    bool nakyvissa_ = false;

    void Awake(){
    	avain_ = GameState.Instance.getAvainLoydetty();
    }

    void OnMouseDown(){
    	if(!avain_){
    		avain_ = true;
    		GameState.Instance.setAvainLoydetty(avain_);
            kupla_.show();
            nakyvissa_ = true;
            time_ = Time.time;

    	}
    	else{
    		Debug.Log("You already found the key...");
    	}
    }

    void Update(){
        float delta = Time.time - time_;
        if(nakyvissa_){
            timeLeft_ -= delta;
            if(timeLeft_ <= 0.0){
                kupla_.hide();
                nakyvissa_ = false;
                timeLeft_ = 2000.0f;
            }
        }
    }


}