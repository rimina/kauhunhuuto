using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour{

    [SerializeField] RoomScript huone_;

    void OnMouseDown(string scene){
        huone_.changescene(scene);
    }
}