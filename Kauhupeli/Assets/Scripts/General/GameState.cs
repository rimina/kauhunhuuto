using UnityEngine;
using System.Collections;

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

    private bool onWindow_ = false;

    private bool gameEnded_ = false;

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
    }
    public int getBeastSightCount(){
        return beastSightCount_;
    }

    //IKKUNA
    public bool onWindow(){
        return onWindow_;
    }
    public void setWindow(bool on){
        onWindow_ = on;
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


    //L????KE
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

    public bool kirjaLoydettavissa(){
        if(ruokaValmis_ && !ruokaViety_){
            return true;
        }
        else{
            return false;
        }
    }

    public bool gameEnded(){
        return gameEnded_;
    }
    public void setGameEnded(bool val){
        gameEnded_ = val;
    }


    //END CONDITIONS
    public Loppu checkEndCondition(){
        if(beastSightCount_ >= 3){
            return Loppu.PETOKUOLEMA;
        }
        else if(laakeVietyYstavalle_ && !ruokaViety_){
            return Loppu.NEUTRAL;

        }
        else if(ruokaViety_ && laakeVietyParonille_ && !myrkytetty_){
            return Loppu.BARON;
        }
        else if(ruokaViety_ && !myrkytetty_){
            return Loppu.BAD;
        }

        else if(ruokaViety_ && myrkytetty_){
            return Loppu.GOOD;
        }
        else{
            return Loppu.JATKUU;
        }
    }
}