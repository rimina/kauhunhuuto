using UnityEngine;
using System.Collections;

public class Kinkku : MonoBehaviour{

    [SerializeField] Cooking kokkaus_;
    [SerializeField] Annos lautanen_;
    public GameObject gameObj;

    private Vector3 originalPos_;
    private RaakaAine tila_;

    void Awake(){
        tila_ = GameState.Instance.getIngredientState(Aine.Kinkku);
        Debug.Log("Kikku awakened!");
        if(GameState.Instance.getKeittiossaKayty() == 0){
            Debug.Log("Alustetaan kinkku ekan kerran");
            tila_.nimi = Aine.Kinkku;
            tila_.alkuPaikka = gameObj.transform.localPosition;
            tila_.paikka = gameObj.transform.localPosition;
            tila_.ruoassa = false;
            GameState.Instance.setIngredientState(tila_);
        }
        
        originalPos_ = tila_.alkuPaikka;
    }

    void Start(){
        gameObj.transform.localPosition = tila_.paikka;
    }

    void OnMouseDown(){
        Debug.Log("klik!");
        if(!tila_.ruoassa){
            kokkaus_.addIngredient(Aine.Kinkku);
            tila_.ruoassa = true;
            Vector3 lautasenPaikka = lautanen_.gameObj.transform.localPosition;
            gameObj.transform.localPosition = new Vector3(lautasenPaikka.x, lautasenPaikka.y, originalPos_.z);
        }
        else{
            kokkaus_.removeIngredient(Aine.Kinkku);
            tila_.ruoassa = false;
            gameObj.transform.localPosition = originalPos_;
        }
        tila_.paikka = gameObj.transform.localPosition;
        GameState.Instance.setIngredientState(tila_);
    }
}