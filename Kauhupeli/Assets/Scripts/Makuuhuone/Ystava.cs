using UnityEngine;
using System.Collections;

public class Ystava : MonoBehaviour{

    [SerializeField] Puhekupla kupla_;

    void OnMouseDown(){
        if(GameState.Instance.getLaakeLoydetty()){
            Debug.Log("You saved your friend!");
            GameState.Instance.setLaakeVietyYstavalle(true);
        }
        else{
            Debug.Log("Bring me the medicine or I die!");
            if(!kupla_.nakyyko()){
                kupla_.show();
            }
            else{
                kupla_.hide();
            }
        }
    }
}