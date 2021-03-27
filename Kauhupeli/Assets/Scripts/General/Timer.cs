using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour{
    private float timeLeft_ = 10000.0f;
    private float time_ = 0.0f;
    private Beast baron_;

    void Awake(){
        baron_ = GetComponent<Beast>();
    }

    void Start(){
        Debug.Log(baron_);
        time_ = Time.time;
        Debug.Log("start time: " + time_);
    }

    public void Update(){
        float delta = Time.time - time_;
        timeLeft_ -= delta;

        if(timeLeft_ <= 0.0){
            timeLeft_ = 10000.0f;
            time_ = Time.time;

            if(!baron_.soi()){
                baron_.PlayAudio();
            }
            else{
                baron_.stopAudio();
            }

            baron_.spawn();
        }
    }
}