using UnityEngine;
using System.Collections;

public class Annos : MonoBehaviour{

    public GameObject gameObj;
    public GameObject kala;
    public GameObject piiras;
    public GameObject keitto;

    private GameObject ateriakuva_;

    public void setImage(Ateria ateria){
        if(ateria == Ateria.KALA){
            ateriakuva_ = Instantiate(kala, transform.position, Quaternion.identity);
        }
        else if(ateria == Ateria.KEITTO){
            ateriakuva_ = Instantiate(keitto, transform.position, Quaternion.identity);
        }
        else if(ateria == Ateria.PIIRAS){
            ateriakuva_ = Instantiate(piiras, transform.position, Quaternion.identity);
        }

        Vector3 pos = ateriakuva_.transform.localPosition;
        ateriakuva_.transform.localPosition = new Vector3(pos.x, pos.y, -5);
        gameObj.SetActive(false);

    }
}