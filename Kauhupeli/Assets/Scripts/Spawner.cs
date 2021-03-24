using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject objectToSpawn;

	public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {

     Instantiate(objectToSpawn, transform.position, Quaternion.identity);
     Debug.Log("Object spawned");
     
    }

    public void PlayAudio()
    {
    	PlaySoundClip();
    }

    private void PlaySoundClip()
    {
    	AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    	Debug.Log("Musa soi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
