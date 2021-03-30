using UnityEngine;
using System.Collections;

public class Ikkuna : MonoBehaviour{

    void Awake(){
        GameState.Instance.setWindow(true);
        Debug.Log("ollaan ikkunassa");
    }

    void OnDestroy(){
        GameState.Instance.setWindow(false);
        Debug.Log("ei olla enää ikkunassa");
    }
}