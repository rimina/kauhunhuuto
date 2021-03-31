using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour{
    private float timeLeft_ = 0.0f;
    private float time_ = 0.0f;
    private Beast baron_;

    void Awake(){
        baron_ = GetComponent<Beast>();
    }

    void Start(){
        time_ = Time.time;
        if(GameState.Instance.onWindow()){
            timeLeft_ = Random.Range(2.0f, 10.0f)*1000.0f;
        }
        else{
            timeLeft_ = Random.Range(40.0f, 120.0f)*1000.0f;
        }
        Debug.Log("time left: " + timeLeft_);
        
    }

    public void Update(){
        float delta = Time.time - time_;
        timeLeft_ -= delta;

        if(timeLeft_ <= 0.0){
            time_ = Time.time;

            //Jos paroni spawnasi, se piilotetaan 3s päästä
            if(baron_.spawn()){
                timeLeft_ = 300.0f;
            }
            else{
                //Muuten arvotaan random väli
                timeLeft_ = Random.Range(40.0f, 120.0f)*1000.0f;
                Debug.Log("time left: " + timeLeft_);

            }
            
        }
    }
}