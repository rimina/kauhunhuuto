using UnityEngine;
using System.Collections;

public class Kirja : MonoBehaviour{

    [SerializeField] RoomScript huone_;
    public GameObject kirja_;

    void Awake(){
        kirja_.SetActive(GameState.Instance.kirjaLoydettavissa());
    }

    void OnMouseDown(){
        if(GameState.Instance.kirjaLoydettavissa()){
            huone_.changescene("Kirja");
        }
    }
}