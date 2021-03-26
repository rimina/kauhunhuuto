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

    private bool avain_ = false;
    private bool laake_ = false;
    private bool ruokaViety_ = false;
    private bool myrkytetty_ = false;
    private bool laakeVietyYstavalle_ = false;
    private bool laakeAnnettuParonille_ = false;

    public static GameState Instance{
        get{
            if(GameState.instance_ == null){
                GameState.instance_ = new GameState();
            }
            return GameState.instance_;
        }
    }

    public void beastSeen(){
        ++beastSightCount_;
        Debug.Log("Beast seen: " + beastSightCount_);
    }

    public int getBeastSightCount(){
        return beastSightCount_;
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
        else if(ruokaViety_ && laakeVietyYstavalle_){
            Debug.Log("Sinä ja ystäväsi selvisitte");
            //return Loppu.YSTAVA_PELAAJA;
            return true;
        }
        else if(ruokaViety_ && laakeAnnettuParonille_){
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