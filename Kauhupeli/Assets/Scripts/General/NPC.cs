using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;

    void OnMouseDown(){
        if(!kupla_.nakyyko()){
            kupla_.show();
        }
        else{
            kupla_.hide();
        }
    }
}