using UnityEngine;
using System.Collections;

public class RuokiParoni : MonoBehaviour{

    [SerializeField] Puhekupla ruokakupla_;
    [SerializeField] Puhekupla laakekupla_;
    [SerializeField] AudioSource asmr_;

    private bool ruokaViety_ = false;
    private bool kuollut_ = false;
    private bool laake_ = false;

    private float rkTimeLeft_ = 2000.0f;
    private float rkTime_ = 0.0f;
    private bool rkNakyvissa_ = false;

    private float lkTimeLeft_ = 2000.0f;
    private float lkTime_ = 0.0f;
    private bool lkNakyvissa_ = false;


    void Awake(){
        rkTime_ = Time.time;
        lkTime_ = Time.time;
        if((GameState.Instance.getLaakeLoydetty() && !GameState.Instance.getLaakeVietyYstavalle()) ||
            GameState.Instance.getLaakeVietyParonille()){

            laake_ = true;
        }

    	ruokaViety_ = GameState.Instance.getRuokaViety();
    	if(ruokaViety_ && GameState.Instance.getMyrkytys()){
    		kuollut_ = true;
    	}
    }

    void OnMouseDown(){
        if(laake_ && !kuollut_){
            laakekupla_.show();
            lkNakyvissa_ = true;
            lkTime_ = Time.time;
            GameState.Instance.setLaakeVietyParonille(true);
        }

    	if(GameState.Instance.getRuokaValmis() && !ruokaViety_){
    		ruokaViety_ = true;
    		kuollut_ = GameState.Instance.getMyrkytys();

            GameState.Instance.setRuokaViety(ruokaViety_);
    	}
    	else if(!GameState.Instance.getRuokaValmis()){
            ruokakupla_.show();
            rkNakyvissa_ = true;
            rkTime_ = Time.time;
    	}

        if(!asmr_.isPlaying){
            asmr_.Play();
        }
        else{
            asmr_.Stop();
        }
    }

    void Update(){
        float rkDelta = Time.time - rkTime_;
        if(rkNakyvissa_){
            rkTimeLeft_ -= rkDelta;
            if(rkTimeLeft_ <= 0.0){
                ruokakupla_.hide();
                rkNakyvissa_ = false;
                rkTimeLeft_ = 2000.0f;
            }
        }

        float lkDelta = Time.time - lkTime_;
        if(lkNakyvissa_){
            lkTimeLeft_ -= lkDelta;
            if(lkTimeLeft_ <= 0.0){
                laakekupla_.hide();
                lkNakyvissa_ = false;
                lkTimeLeft_ = 2000.0f;
            }
        }
    }
}