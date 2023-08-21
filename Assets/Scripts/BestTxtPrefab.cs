using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestTxtPrefab: MonoBehaviour {
    
    void Awake(){
        Destroy(gameObject, 5.0f);
        int bestDistance = PlayerPrefs.GetInt("bestDistance", 0);
        GetComponent<TMP_Text>().text = Lang.bestStr() + bestDistance.ToString(); 
    }

    // Start is called before the first frame update
    void Start() {

    }

    void Update(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 13.0f * Time.deltaTime);
    }

}// ./ end