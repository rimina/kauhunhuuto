using UnityEngine;
using System.Collections;


//HUOM placeholder ainekset
public enum Aine{
    Tyhja,
    Kinkku,
    Kananmuna,
    Maito,
    Lammas,
    Mika,
    Faija,
    BMW
}

public struct Resepti{
    public bool myrkky_;
    public Aine[] ainekset_;
}

public class Cooking : MonoBehaviour{


    private Resepti munakas_;
    private Resepti kela_;
    private Resepti muu_;

    public Resepti pelaaja_;

    //alustetaan tila
    void Awake(){

        //HUOM, placeholder reseptit
        munakas_.myrkky_ = false;
        munakas_.ainekset_ = new Aine[] {Aine.Kinkku, Aine.Kananmuna, Aine.Maito};

        kela_.myrkky_ = true;
        kela_.ainekset_ = new Aine[] {Aine.Mika, Aine.Faija, Aine.BMW};

        muu_.myrkky_ = false;
        muu_.ainekset_ = new Aine[] {Aine.Lammas, Aine.Mika, Aine.Faija};

        pelaaja_.myrkky_ = false;
        pelaaja_.ainekset_ = new Aine[] {Aine.Tyhja, Aine.Tyhja, Aine.Tyhja};
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
            return true;
        }
        else if(onkoOikeaResepti(kela_)){
            return true;
        }
        else if(onkoOikeaResepti(muu_)){
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
        for(int i = 0; i < 3; ++i){
            if(pelaaja_.ainekset_[i] == Aine.Tyhja){
                pelaaja_.ainekset_[i] = ingredient;
                Debug.Log("added ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                return true;
            }
        }
        Debug.Log("no room for new ingredients");
        return false;
    }

    //poistaa aineksen pelaajan tekemästä ruoasta
    public bool removeIngredient(Aine ingredient){
        for(int i = 0; i < 3; ++i){
            if(pelaaja_.ainekset_[i] == ingredient){
                Debug.Log("removed ingredient: " + pelaaja_.ainekset_[i] + " at position " + i);
                pelaaja_.ainekset_[i] = Aine.Tyhja;
                return true;
            }
        }
        Debug.Log("ingredient not found");
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