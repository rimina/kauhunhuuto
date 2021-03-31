using UnityEngine;
using System.Collections;

public class Vitsi : MonoBehaviour{

    [SerializeField] AudioSource vitsi_;

    void OnMouseDown(){
        if(!vitsi_.isPlaying){
            vitsi_.Play();
        }
        else{
            vitsi_.Stop();
        }
    }
}