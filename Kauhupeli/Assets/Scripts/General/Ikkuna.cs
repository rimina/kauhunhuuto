using UnityEngine;
using System.Collections;

public class Ikkuna : MonoBehaviour{

    void Awake(){
        GameState.Instance.setWindow(true);
    }

    void OnDestroy(){
        GameState.Instance.setWindow(false);
    }
}