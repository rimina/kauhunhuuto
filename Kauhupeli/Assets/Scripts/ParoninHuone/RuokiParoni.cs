using UnityEngine;
using System.Collections;

public class RuokiParoni : MonoBehaviour{
    public GameObject gameObj;
    [SerializeField] Puhekupla kupla_;

    private bool ruokaViety_ = false;
    private bool kuollut_ = false;

    private float timeLeft_ = 2000.0f;
    private float time_ = 0.0f;
    bool nakyvissa_ = false;

    void Awake(){
    	ruokaViety_ = GameState.Instance.getRuokaViety();
    	if(ruokaViety_ && GameState.Instance.getMyrkytys()){
    		kuollut_ = true;
    	}
    }

    void OnMouseDown(){
    	if(GameState.Instance.getRuokaValmis() && !ruokaViety_){
    		ruokaViety_ = true;
    		GameState.Instance.setRuokaViety(ruokaViety_);
    		kuollut_ = GameState.Instance.getMyrkytys();
            kupla_.show();
            nakyvissa_ = true;
            time_ = Time.time;
    	}
    	else if(!GameState.Instance.getRuokaValmis()){
    		Debug.Log("You need to make the food first");
    	}
    	else if(ruokaViety_){
    		Debug.Log("You already did this");
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