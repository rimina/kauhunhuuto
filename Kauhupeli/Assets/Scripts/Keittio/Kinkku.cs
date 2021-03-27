using UnityEngine;
using System.Collections;

public class Kinkku : MonoBehaviour{

    [SerializeField] Cooking kokkaus_;
    [SerializeField] Annos lautanen_;
    public GameObject gameObj;

    private Vector3 originalPos_;

    private bool added_ = false;
    void Awake(){
        originalPos_ = gameObj.transform.localPosition;
    }

    void OnMouseDown(){
        Debug.Log("klik!");
        if(!added_){
            kokkaus_.addIngredient(Aine.Kinkku);
            added_ = true;
            Vector3 lautasenPaikka = lautanen_.gameObj.transform.localPosition;
            gameObj.transform.localPosition = new Vector3(lautasenPaikka.x, lautasenPaikka.y, originalPos_.z);
        }
        else{
            kokkaus_.removeIngredient(Aine.Kinkku);
            added_ = false;
            gameObj.transform.localPosition = originalPos_;
        }
    }
}