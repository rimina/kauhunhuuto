using UnityEngine;
using System.Collections;

public class Kirja : MonoBehaviour{

    [SerializeField] RoomScript huone_;

    void OnMouseDown(){
        huone_.changescene("Kirja");
    }
}