using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : MonoBehaviour
{

	public GameObject objectToSpawn;
    private GameObject theRealObject_;
    private Animator animaatio_;

    private AudioSource jingle_;
    private bool soi_ = false;
    private bool spawned_ = false;
    
    // Start is called before the first frame update
    void Start(){
        jingle_ = GetComponent<AudioSource>();
        animaatio_ = GetComponent<Animator>();

        theRealObject_= Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        theRealObject_.SetActive(false);
    }

    private void playAudio()
    {
        if(!soi_){
            jingle_.Play();
            animaatio_.SetBool("Beastanim", true);
            soi_ = true;
        }
    }

    private void stopAudio(){
        if(soi_){
            jingle_.Stop();
            animaatio_.SetBool("Beastanim", false);
            soi_ = false;
        }
    }

    public bool nakyy(){
        return spawned_;
    }

    public bool spawn(){
        if(!spawned_){
            theRealObject_.SetActive(true);
            spawned_ = true;
            playAudio();
        }
        else{
            GameState.Instance.beastSeen();
            theRealObject_.SetActive(false);
            spawned_ = false;
            stopAudio();
        }

        return spawned_;
    }
}
