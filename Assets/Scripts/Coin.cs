using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    GameScene gs;

     //-------------------------------------------
    // MARK - AWAKE
    //-------------------------------------------
    void Awake(){
        Destroy(gameObject, 5.0f);
        
        // Init scripts
        gs = GameObject.FindObjectOfType(typeof(GameScene)) as GameScene;
    }

    // Start is called before the first frame update
    void Start() {
        GetComponent<Animation>().Play("coinAnim");
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            gameObject.SetActive(false);
            gs.updateCoins();
        }
    }

    void Update(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 13.0f * Time.deltaTime);
    }

}// ./ end