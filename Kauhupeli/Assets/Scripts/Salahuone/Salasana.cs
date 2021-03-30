using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Salasana : MonoBehaviour{

    [SerializeField] RoomScript huone_;
    [SerializeField] InputField input_;

    private string salasana_ = "LAURI";

    public void CheckString(){
        string verrattava = input_.text.ToUpper();
        if(salasana_.Equals(verrattava)){
            huone_.changescene("11Salahuone");
        }
    }
}