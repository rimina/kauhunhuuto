using UnityEngine;
using System.Collections;

public class Myrkky : MonoBehaviour{
    public GameObject gameObj;
    [SerializeField] Puhekupla myrkkyteksti_;

    private float timeLeft_ = 1000.0f;
    private float time_ = 0.0f;
    private bool nakyvissa_ = false;


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
            myrkkyteksti_.show();
            nakyvissa_ = true;
    	}
    	else{
    		Debug.Log("why am I still visible?");
    	}
    }

    void Update(){
        float delta = Time.time - time_;
        if(nakyvissa_){
            timeLeft_ -= delta;
            if(timeLeft_ <= 0.0){
                myrkkyteksti_.hide();
                nakyvissa_ = false;
                gameObj.SetActive(false);
            }
        }
    }
}