using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;
    private float timeLeft_ = 1500.0f;
    private float time_ = 0.0f;

    void OnMouseDown(){
        if(!kupla_.nakyyko()){
            kupla_.show();
        }
        else{
            kupla_.hide();
        }
    }

    void Update(){
        float delta = Time.time - time_;
        if(kupla_.nakyyko()){
            timeLeft_ -= delta;
            if(timeLeft_ <= 0.0){
                timeLeft_ = 1500.0f;
                time_ = Time.time;
                kupla_.hide();
            }
        }
    }
}