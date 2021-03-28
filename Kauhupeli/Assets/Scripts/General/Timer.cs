using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour{
    private float timeLeft_ = 0.0f;
    private float time_ = 0.0f;
    private Beast baron_;
    private Animator anim;

    void Awake(){
        timeLeft_ = Random.Range(10.0f, 60.0f)*1000.0f;
        baron_ = GetComponent<Beast>();
    }

    void Start(){
        Debug.Log(baron_);
        time_ = Time.time;
        Debug.Log("time left: " + timeLeft_);

        anim = GetComponent<Animator>();
        
    }

    public void Update(){
        float delta = Time.time - time_;
        timeLeft_ -= delta;

        if(timeLeft_ <= 0.0){
            time_ = Time.time;

            //Jos paroni spawnasi, se piilotetaan 5s päästä
            if(baron_.spawn()){
                timeLeft_ = 500.0f;

                anim.SetBool("Beastanim", true);
                anim.SetBool("Beastanim", false);
            }
            else{
                //Muuten arvotaan random väli
                timeLeft_ = Random.Range(10.0f, 60.0f)*1000.0f;
                Debug.Log("time left: " + timeLeft_);

                anim.SetBool("Beastanim", false);
                anim.SetBool("Beastanim", true);

            }
            
        }
    }
}