using System.Collections;
using UnityEngine;

public class Puhekupla : MonoBehaviour{
    public GameObject objectToSpawn;
    private GameObject theRealObject_;

    private bool nakyy_ = false;

    void Start(){
        theRealObject_= Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        theRealObject_.SetActive(false);
    }

    public void show(){
        theRealObject_.SetActive(true);
        nakyy_ = true;
        Debug.Log("Puhekuplan pitäisi näkyä");
    }

    public void hide(){
        theRealObject_.SetActive(false);
        nakyy_ = false;
        Debug.Log("Puhekuplan ei pitäisi näkyä");
    }

    public bool nakyyko(){
        return nakyy_;
    }
}
