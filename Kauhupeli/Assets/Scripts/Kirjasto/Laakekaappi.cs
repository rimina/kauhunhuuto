using UnityEngine;
using System.Collections;

public class Laakekaappi : MonoBehaviour{

    [SerializeField] RoomScript huone_;

    void OnMouseDown(){
        if(GameState.Instance.getAvainLoydetty()){
            huone_.changescene("Laakekaappi");
        }
        else{
            Debug.Log("You need to find the key first!");
        }
    }
}