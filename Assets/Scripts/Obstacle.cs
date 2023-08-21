using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
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
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            gs.gameOver();
            Destroy(gameObject);
        }
    }

    void Update(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 13.0f * Time.deltaTime);
    }

}// ./ end