using UnityEngine;
using System.Collections;

public enum Ateria{
    KALA,
    PIIRAS,
    KEITTO,

    KESKEN
}


public struct Resepti{
    public Aine[] ainekset_;
    public bool superior_;
    public bool valmis_;
    public Ateria nimi_;
}

public class Cooking : MonoBehaviour{

    [SerializeField] Annos lautanen_;
    [SerializeField] AudioSource tirina_;

    private Resepti kala_;
    private Resepti piiras_;
    private Resepti keitto_;

    private Resepti pelaaja_;
    private Vector3 kattilaPos_;

    //alustetaan tila
    void Awake(){
        //HUOM, placeholder reseptit
        kala_.valmis_ = true;
        kala_.superior_ = true;
        kala_.nimi_ = Ateria.KALA;
        kala_.ainekset_ = new Aine[] {Aine.LOHI, Aine.SITRUUNA, Aine.SALAATTI};

        piiras_.valmis_ = false;
        piiras_.superior_ = true;
        piiras_.nimi_ = Ateria.PIIRAS;
        piiras_.ainekset_ = new Aine[] {Aine.JANIS, Aine.SIPULI, Aine.SIENET};

        keitto_.valmis_ = true;
        keitto_.superior_ = false;
        keitto_.nimi_ = Ateria.KEITTO;
        keitto_.ainekset_ = new Aine[] {Aine.KANA, Aine.PORKKANA, Aine.NAURIS};

    }

    void Start(){
        pelaaja_ = GameState.Instance.getPlayerRecipe();

        if(pelaaja_.ainekset_ == null){
            pelaaja_.ainekset_ = new Aine[] {Aine.TYHJA, Aine.TYHJA, Aine.TYHJA};
            pelaaja_.superior_ = false;
            pelaaja_.valmis_ = false;
            pelaaja_.nimi_ = Ateria.KESKEN;
            GameState.Instance.setPlayerRecipe(pelaaja_);
        }

        if(pelaaja_.valmis_){
            lautanen_.setImage(pelaaja_.nimi_);
        }

    }

    void OnDestroy(){
        GameState.Instance.keittiossaKayty();
    }

    //Apufunktio reseptin tarkastukseen
    private bool onkoOikeaResepti(Resepti vertailtava){
        int oikein = 0;
        for(int i = 0; i < 3; ++i){
            Aine aines = pelaaja_.ainekset_[i];
            for(int j = 0; j < 3; ++j){
                if(aines == vertailtava.ainekset_[j]){
                    ++oikein;
                }
            }
        }
        if(oikein == 3){
            Debug.Log("ruoka on valmis");
            pelaaja_.nimi_ = vertailtava.nimi_;
            pelaaja_.valmis_ = vertailtava.valmis_;
            pelaaja_.superior_ = vertailtava.superior_;
            return true;
        }
        else{
            Debug.Log("ei ollut oikea resepti");
            return false;
        }
    }

    //Tarkastaa onko pelaajan tekemä ruoka mikään resepteistä
    public bool checkFood(){
        if(!GameState.Instance.getRuokaValmis()){
            bool valmis = false;
            if(onkoOikeaResepti(kala_)){
                valmis = true;
            }
            else if(onkoOikeaResepti(piiras_)){
                valmis = true;
            }
            else if(onkoOikeaResepti(keitto_)){
                valmis = true;
            }
            if(valmis){
                GameState.Instance.setRuokaValmis(valmis);
                lautanen_.setImage(pelaaja_.nimi_);
            }
            
            GameState.Instance.setPlayerRecipe(pelaaja_);
            

            return valmis;
        }
        else{
            return true;
        }
    }

    //Lisää aineksen pelaajan tekemään ruokaan
    public bool addIngredient(Aine ingredient){
        if(!GameState.Instance.getRuokaValmis()){
            bool ok = false;
            int index = 0;
            for(int i = 0; i < 3; ++i){
                if(pelaaja_.ainekset_[i] == Aine.TYHJA){
                    pelaaja_.ainekset_[i] = ingredient;
                    index = i;
                    Debug.Log("added ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                    ok = true;
                    break;
                }
            }
            if(ok){
                GameState.Instance.setPlayerRecipe(pelaaja_);
                if(!tirina_.isPlaying){
                    tirina_.Play();
                }
                if(index == 2){
                    if(checkFood()){
                        if(tirina_.isPlaying){
                            tirina_.Stop();
                        }
                    }
                }
            }
            else{
                Debug.Log("no room for new ingredients");
            }
            return ok;
        }
        else{
            Debug.Log("ruoka on jo tehty");
            return false;
        }
        
    }

    private bool onkoTyhja(bool[] tyhja){
        bool ok = true;
        for(int i = 0; i < tyhja.Length; ++i){
            if(!tyhja[i]){
                ok = false;
                break;
            }
        }
        return ok;
    }

    //poistaa aineksen pelaajan tekemästä ruoasta
    public bool removeIngredient(Aine ingredient){
        if(!GameState.Instance.getRuokaValmis()){
            bool ok = false;
            bool[] tyhja = {false, false, false};
            for(int i = 0; i < 3; ++i){
                if(pelaaja_.ainekset_[i] == ingredient){
                    Debug.Log("removed ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                    pelaaja_.ainekset_[i] = Aine.TYHJA;
                    ok = true;
                }
                if(pelaaja_.ainekset_[i] == Aine.TYHJA){
                    tyhja[i] = true;
                }
            }
            if(ok){
                GameState.Instance.setPlayerRecipe(pelaaja_);
            }
            else{
                Debug.Log("ingredient not found");
            }

            if(onkoTyhja(tyhja) && tirina_.isPlaying){
                tirina_.Stop();
            }

            return ok;
        }
        else{
            Debug.Log("ruoka on jo tehty");
            return false;
        }
    }
}