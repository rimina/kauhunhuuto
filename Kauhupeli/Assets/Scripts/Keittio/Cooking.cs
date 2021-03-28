using UnityEngine;
using System.Collections;


//HUOM placeholder ainekset
public enum Aine{
    Kinkku,
    Kananmuna,
    Kala,
    Leipa,
    Salaatti,
    Maito,
    Lammas,
    Mika,
    Faija,
    Tyhja
}

public struct Resepti{
    public bool myrkky_;
    public Aine[] ainekset_;
    public bool superior_;
    public bool valmis_;
}

public struct RaakaAine{
    public Aine nimi;
    public Vector3 alkuPaikka;
    public Vector3 paikka;
    public bool ruoassa;
    public bool alustettu;
}

public class Cooking : MonoBehaviour{


    private Resepti munakas_;
    private Resepti kela_;
    private Resepti muu_;

    private Resepti pelaaja_;
    private Vector3 kattilaPos_;

    //alustetaan tila
    void Awake(){

        //HUOM, placeholder reseptit
        munakas_.myrkky_ = false;
        munakas_.superior_ = false;
        munakas_.valmis_ = true;
        munakas_.ainekset_ = new Aine[] {Aine.Kinkku, Aine.Kananmuna, Aine.Maito};

        kela_.myrkky_ = true;
        kela_.valmis_ = true;
        kela_.superior_ = true;
        kela_.ainekset_ = new Aine[] {Aine.Mika, Aine.Faija, Aine.Lammas};

        muu_.myrkky_ = false;
        muu_.superior_ = false;
        muu_.valmis_ = true;
        muu_.ainekset_ = new Aine[] {Aine.Lammas, Aine.Kala, Aine.Salaatti};


    }

    void Start(){
        pelaaja_ = GameState.Instance.getPlayerRecipe();
        if(pelaaja_.ainekset_ == null){
            Debug.Log("Ei alustettu!");
            pelaaja_.ainekset_ = new Aine[] {Aine.Tyhja, Aine.Tyhja, Aine.Tyhja};
            pelaaja_.myrkky_ = false;
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
            if(oikein < i){
                return false;
            }
        }
        if(oikein == 3){
            return true;
        }
        else{
            Debug.Log("something is funny");
            return false;
        }
    }

    //Tarkastaa onko pelaajan tekemä ruoka mikään resepteistä
    public bool checkFood(){
        if(onkoOikeaResepti(munakas_)){
            pelaaja_.valmis_ = true;
            pelaaja_.superior_ = false;
            return true;
        }
        else if(onkoOikeaResepti(kela_)){
            pelaaja_.superior_ = true;
            pelaaja_.valmis_ = true;
            return true;
        }
        else if(onkoOikeaResepti(muu_)){
            pelaaja_.valmis_ = true;
            pelaaja_.superior_ = false;
            return true;
        }
        else{
            return false;
        }
    }

    //Myrkyttää ruoan
    public void addPoison(){
        pelaaja_.myrkky_ = true;
    }

    //Lisää aineksen pelaajan tekemään ruokaan
    public bool addIngredient(Aine ingredient){
        bool ok = false;
        for(int i = 0; i < 3; ++i){
            if(pelaaja_.ainekset_[i] == Aine.Tyhja){
                pelaaja_.ainekset_[i] = ingredient;
                Debug.Log("added ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                ok = true;
                break;
            }
        }
        if(ok){
            GameState.Instance.setPlayerRecipe(pelaaja_);
        }
        else{
            Debug.Log("no room for new ingredients");
        }
        return ok;
    }

    //poistaa aineksen pelaajan tekemästä ruoasta
    public bool removeIngredient(Aine ingredient){
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
        return false;
    }

    //tarkastetaan, onko ruoka myrkytettyä
    public bool isPoisoned(){
        return pelaaja_.myrkky_;
    }

    //Nollaa ruoan (aloitta alusta)
    public void startOver(){
        pelaaja_.myrkky_ = false;
        pelaaja_.ainekset_ = new Aine[] {Aine.Tyhja, Aine.Tyhja, Aine.Tyhja};
    }
}