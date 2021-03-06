using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//HUOM placeholder ainekset
public enum Aine{
    LOHI,
    SITRUUNA,
    SALAATTI,

    JANIS,
    SIPULI,
    SIENET,
    
    KANA,
    PORKKANA,
    NAURIS,

    TYHJA
}

public struct RaakaAine{
    public Aine nimi;
    public Vector3 alkuPaikka;
    public Vector3 paikka;
    public bool ruoassa;
    public bool alustettu;
}

public class Aines : MonoBehaviour{

    [SerializeField] Cooking kokkaus_;
    [SerializeField] Annos lautanen_;

    private Dictionary<string, Aine> mapping_;

    public GameObject gameObj;

    private Vector3 originalPos_;
    private RaakaAine tila_;

    private Aine nimi_;

    void Awake(){

        //Alustetaan ainesosamappi
        mapping_ = new Dictionary<string, Aine>();
        mapping_.Add("Lohi", Aine.LOHI);
        mapping_.Add("Sitruuna", Aine.SITRUUNA);
        mapping_.Add("Salaatti", Aine.SALAATTI);

        mapping_.Add("Janis", Aine.JANIS);
        mapping_.Add("Sipuli", Aine.SIPULI);
        mapping_.Add("Sienet", Aine.SIENET);

        mapping_.Add("Kana", Aine.KANA);
        mapping_.Add("Porkkana", Aine.PORKKANA);
        mapping_.Add("Nauris", Aine.NAURIS);

        //Alustetaan ainesosa...
        string[] nimi = gameObj.ToString().Split(' ');
        nimi_ = mapping_[nimi[0]];

        //Tilan alustaminen
        tila_ = GameState.Instance.getIngredientState(nimi_);
        if(GameState.Instance.getKeittiossaKayty() == 0){
            tila_.nimi = nimi_;
            tila_.alkuPaikka = gameObj.transform.localPosition;
            tila_.paikka = gameObj.transform.localPosition;
            tila_.ruoassa = false;
            GameState.Instance.setIngredientState(tila_);
        }

        //paikan alustaminen
        originalPos_ = tila_.alkuPaikka;
    }

    void Start(){
        gameObj.transform.localPosition = tila_.paikka;
    }

    public void hide(){
        gameObj.SetActive(false);
    }

    void OnMouseDown(){
        if(!tila_.ruoassa){
            if(kokkaus_.addIngredient(nimi_)){
                tila_.ruoassa = true;
                Vector3 lautasenPaikka = lautanen_.gameObj.transform.localPosition;
                gameObj.transform.localPosition = new Vector3(lautasenPaikka.x, lautasenPaikka.y, originalPos_.z);
            }
        }
        else{
            if(kokkaus_.removeIngredient(nimi_)){
                tila_.ruoassa = false;
                gameObj.transform.localPosition = originalPos_;
            }
        }

        tila_.paikka = gameObj.transform.localPosition;
        GameState.Instance.setIngredientState(tila_);
    }
}