using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : MonoBehaviour
{

	public GameObject objectToSpawn;
    private GameObject theRealObject_;

    private AudioSource jingle_;
    private bool soi_ = false;
    private bool spawned_ = false;

    //[SerializeField] RoomScript room_;
    
    // Start is called before the first frame update
    void Start(){

        jingle_ = GetComponent<AudioSource>();
        //Debug.Log(room_);
        theRealObject_= Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        theRealObject_.SetActive(false);
    }

    private void playAudio()
    {
        if(!soi_){
            jingle_.Play();
            Debug.Log("Musa soi");
            soi_ = true;
        }
    }

    private void stopAudio(){
        if(soi_){
            jingle_.Stop();
            Debug.Log("Musa ei soi");
            soi_ = false;
        }
    }

    public bool nakyy(){
        return spawned_;
    }

    public bool spawn(){
        if(!spawned_){
            theRealObject_.SetActive(true);
            Debug.Log("Object spawned");
            spawned_ = true;
            playAudio();
            GameState.Instance.beastSeen();
        }
        else{
            theRealObject_.SetActive(false);
            spawned_ = false;
            stopAudio();
        }

        return spawned_;
    }
}
