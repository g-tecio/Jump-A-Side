using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    Vector3 vel;
    public GameObject player;

    void Start () {
		
	}//End Start
	
	void Update () {

        if (player.GetComponent<Player>().isDead){
            return;
        }

        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(Camera.main.transform.position.x + 3f, player.transform.position.y, transform.position.z),
            ref vel,
            1f
            );

	}//End Update
}
