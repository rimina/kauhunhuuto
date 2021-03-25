using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject objectToSpawn;
	public AudioClip soundEffect;
    private bool soi_ = false;
    private bool spawned_ = false;
    private RoomScript room_;

    void Awake(){
        room_ = GetComponent<RoomScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(room_);
    }

    public void spawn(){
        if(!spawned_){
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Debug.Log("Object spawned");
            spawned_ = true;
            room_.BeastSeen();
        }   
    }

    public void PlayAudio()
    {
    	PlaySoundClip();
    }

    private void PlaySoundClip()
    {
        if(!soi_){
            /*AudioSource.PlayClipAtPoint(soundEffect, transform.position);*/
            Debug.Log("Musa soi");
            soi_ = true;
        }
    }

    public void stopAudio(){
        if(soi_){
            /*AudioSource.Stop(soundEffect);*/
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
