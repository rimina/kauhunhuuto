using UnityEngine;
using System.Collections;

public class Kinkku : MonoBehaviour{

    [SerializeField] Cooking kokkaus_;
    private bool added_ = false;

    void OnMouseDown(){
        Debug.Log("klik!");
        if(!added_){
            kokkaus_.addIngredient(Aine.Kinkku);
            added_ = true;
        }
        else{
            kokkaus_.removeIngredient(Aine.Kinkku);
            added_ = false;
        }
    }
}