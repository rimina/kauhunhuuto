using UnityEngine;
using System.Collections;


public struct Resepti{
    public Aine[] ainekset_;
    public bool superior_;
    public bool valmis_;
}

public class Cooking : MonoBehaviour{

    private Resepti kala_;
    private Resepti piiras_;
    private Resepti keitto_;

    private Resepti pelaaja_;
    private Vector3 kattilaPos_;

    //alustetaan tila
    void Awake(){
        //HUOM, placeholder reseptit
        kala_.superior_ = false;
        kala_.valmis_ = true;
        kala_.ainekset_ = new Aine[] {Aine.Lohi, Aine.Sitruuna, Aine.Salaatti};

        piiras_.valmis_ = true;
        piiras_.superior_ = true;
        piiras_.ainekset_ = new Aine[] {Aine.Janis, Aine.Sipuli, Aine.Sienet};

        keitto_.superior_ = false;
        keitto_.valmis_ = true;
        keitto_.ainekset_ = new Aine[] {Aine.Kana, Aine.Porkkana, Aine.Nauris};

    }

    void Start(){
        pelaaja_ = GameState.Instance.getPlayerRecipe();
        if(pelaaja_.ainekset_ == null){
            pelaaja_.ainekset_ = new Aine[] {Aine.Tyhja, Aine.Tyhja, Aine.Tyhja};
            pelaaja_.superior_ = false;
            pelaaja_.valmis_ = false;
            GameState.Instance.setPlayerRecipe(pelaaja_);
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
                pelaaja_.valmis_ = true;
                pelaaja_.superior_ = true;
                valmis = true;
            }
            else if(onkoOikeaResepti(piiras_)){
                pelaaja_.superior_ = false;
                pelaaja_.valmis_ = true;
                valmis = true;
            }
            else if(onkoOikeaResepti(keitto_)){
                pelaaja_.valmis_ = true;
                pelaaja_.superior_ = false;
                valmis = true;
            }
            GameState.Instance.setRuokaValmis(valmis);
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
                if(pelaaja_.ainekset_[i] == Aine.Tyhja){
                    pelaaja_.ainekset_[i] = ingredient;
                    index = i;
                    Debug.Log("added ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                    ok = true;
                    break;
                }
            }
            if(ok){
                GameState.Instance.setPlayerRecipe(pelaaja_);
                if(index == 2){
                    checkFood();
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

    //poistaa aineksen pelaajan tekemästä ruoasta
    public bool removeIngredient(Aine ingredient){
        if(!GameState.Instance.getRuokaValmis()){
            bool ok = false;
            for(int i = 0; i < 3; ++i){
                if(pelaaja_.ainekset_[i] == ingredient){
                    Debug.Log("removed ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                    pelaaja_.ainekset_[i] = Aine.Tyhja;
                    ok = true;
                    break;
                }
            }
            if(ok){
                GameState.Instance.setPlayerRecipe(pelaaja_);
            }
            else{
                Debug.Log("ingredient not found");
            }
            return ok;
        }
        else{
            Debug.Log("ruoka on jo tehty");
            return false;
        }
    }
}