using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;

    void OnMouseDown(){
        Debug.Log("klik!");
        if(!kupla_.nakyyko()){
            kupla_.show();
        }
        else{
            kupla_.hide();
        }
    }
}