using UnityEngine;
using System.Collections;

public enum Loppu{
    PETOKUOLEMA,
    YSTAVA,
    PELAAJA,
    YSTAVA_PELAAJA,
    PARONI_PELAAJA,
    JATKUU
}

public class GameState{
    protected GameState(){}
    private static GameState instance_ = null;

    private int beastSightCount_ = 0;
    private Resepti resepti_;
    private bool ruokaValmis_ = false;

    private bool avain_ = false;
    private bool laake_ = false;
    private bool ruokaViety_ = false;
    private bool myrkytetty_ = false;
    private bool laakeVietyYstavalle_ = false;
    private bool laakeVietyParonille_ = false;

    private int keittiossaKayty_ = 0;

    private RaakaAine[] ainekset_ = new RaakaAine[9];

    public static GameState Instance{
        get{
            if(GameState.instance_ == null){
                GameState.instance_ = new GameState();
            }
            return GameState.instance_;
        }
    }

    //PETO
    public void beastSeen(){
        ++beastSightCount_;
        Debug.Log("Beast seen: " + beastSightCount_);
    }
    public int getBeastSightCount(){
        return beastSightCount_;
    }

    //RAAKA-AINEET
    public void setIngredientState(RaakaAine aine){
        ainekset_[(int)aine.nimi] = aine;
    }

    public RaakaAine getIngredientState(Aine index){
        return ainekset_[(int)index];
    }

    //KEITTIO
    public int getKeittiossaKayty(){
        return keittiossaKayty_;
    }
    public void keittiossaKayty(){
        ++keittiossaKayty_;
    }
    public void setPlayerRecipe(Resepti res){
        resepti_ = res;
    }
    public Resepti getPlayerRecipe(){
        return resepti_;
    }
    public bool getRuokaViety(){
        return ruokaViety_;
    }
    public void setRuokaViety(bool viety){
        ruokaViety_ = viety;
    }
    public void setRuokaValmis(bool valmis){
        ruokaValmis_ = valmis;
    }
    public bool getRuokaValmis(){
        return ruokaValmis_;
    }

    //MYKRKKY
    public void setMyrkytys(bool myrkky){
        myrkytetty_ = myrkky;
        Debug.Log("Myrkky: " + myrkytetty_);
    }
    public bool getMyrkytys(){
        return myrkytetty_;
    }

    //AVAIN
    public void setAvainLoydetty(bool loydetty){
        avain_ = loydetty;
    }
    public bool getAvainLoydetty(){
        return avain_;
    }


    //LÄÄKE
    public void setLaakeLoydetty(bool loydetty){
        laake_ = loydetty;
    }
    public bool getLaakeLoydetty(){
        return laake_;
    }
    public void setLaakeVietyYstavalle(bool viety){
        laakeVietyYstavalle_ = viety;
    }
    public bool getLaakeVietyYstavalle(){
        return laakeVietyYstavalle_;
    }
    public void setLaakeVietyParonille(bool viety){
        laakeVietyParonille_ = viety;
    }
    public bool getLaakeVietyParonille(){
        return laakeVietyParonille_;
    }


    //END CONDITIONS
    public bool checkEndCondition(){
        if(beastSightCount_ >= 3){
            Debug.Log("Kuolit pelkoon!");
            //return Loppu.PETOKUOLEMA;
            return true;
        }
        else if(laakeVietyYstavalle_ && !ruokaViety_){
            Debug.Log("Ystävä selvisi, sinä kuolit");
            //return Loppu.YSTAVA;
            return true;

        }
        else if(ruokaViety_ && !laakeVietyYstavalle_){
            Debug.Log("Sinä selvisit, ystäväsi kuoli");
            //return Loppu.PELAAJA;
            return true;
        }
        else if(ruokaViety_ && laakeVietyYstavalle_ && myrkytetty_){
            Debug.Log("Sinä ja ystäväsi selvisitte");
            //return Loppu.YSTAVA_PELAAJA;
            return true;
        }
        else if(ruokaViety_ && laakeVietyParonille_){
            Debug.Log("Petit ystäväsi ja siirryit paronin puolelle");
            //return Loppu.PARONI_PELAAJA;
            return true;
        }
        else{
            //return Loppu.JATKUU;
            return false;
        }
    }
}