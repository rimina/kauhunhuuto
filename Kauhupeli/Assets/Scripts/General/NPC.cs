using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;

    private AudioSource audio_;

    private float timeLeft_ = 2000.0f;
    private float time_ = 0.0f;

    void Start(){
        audio_ = GetComponent<AudioSource>();
        time_ = Time.time;
    }

    void OnMouseDown(){
        if(!kupla_.nakyyko()){
            kupla_.show();
        }
        else{
            kupla_.hide();
        }

        if(audio_ != null){
            if(!audio_.isPlaying){
                audio_.Play();
            }
            else{
                audio_.Stop();
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
                if(audio_ != null){
                    if(audio_.isPlaying){
                        audio_.Stop();
                    }
                }
            }
        }
    }
}