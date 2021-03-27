using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : MonoBehaviour
{

	public GameObject objectToSpawn;
    private GameObject theRealObject_;

    private AudioSource jingleCheek_;
    private bool soi_ = false;
    private bool spawned_ = false;

    [SerializeField] RoomScript room_;
    
    // Start is called before the first frame update
    void Start(){

        jingleCheek_ = GetComponent<AudioSource>();
        Debug.Log(room_);
        theRealObject_= Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        theRealObject_.SetActive(false);
    }

    public void spawn(){
        if(!spawned_){
            theRealObject_.SetActive(true);
            Debug.Log("Object spawned");
            spawned_ = true;
            room_.BeastSeen();
        }
        else{
            theRealObject_.SetActive(false);
            spawned_ = false;
        }
    }

    public void PlayAudio()
    {
    	PlaySoundClip();
    }

    private void PlaySoundClip()
    {
        if(!soi_){
            jingleCheek_.Play();
            Debug.Log("Musa soi");
            soi_ = true;
        }
    }

    public void stopAudio(){
        if(soi_){
            jingleCheek_.Stop();
            Debug.Log("Musa ei soi");
            soi_ = false;
        }
    }

    public bool soi(){
        return soi_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
