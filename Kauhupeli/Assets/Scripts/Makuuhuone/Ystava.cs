using UnityEngine;
using System.Collections;

public class Ystava : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;
    [SerializeField] AudioSource sfx_;

    private float timeLeft_ = 2000.0f;
    private float time_ = 0.0f;

    void Start(){
        time_ = Time.time;
    }

    void OnMouseDown(){
        if(GameState.Instance.getLaakeLoydetty()){
            GameState.Instance.setLaakeVietyYstavalle(true);
        }
        else{
            if(!kupla_.nakyyko()){
                kupla_.show();
            }
            else{
                kupla_.hide();
            }

            if(!sfx_.isPlaying){
                sfx_.Play();
            }
            else{
                sfx_.Stop();
            }
        }
    }

    void Update(){
        float delta = Time.time - time_;
        if(kupla_.nakyyko()){
            timeLeft_ -= delta;
            if(timeLeft_ <= 0.0){
                timeLeft_ = 2000.0f;
                time_ = Time.time;
                kupla_.hide();
            }
        }
    }
}