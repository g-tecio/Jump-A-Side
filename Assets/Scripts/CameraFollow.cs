using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 vel;
    public GameObject player;

	void Start () {

	}//End Start
	
	void Update () {

        if (player.GetComponent<Player>().isDead)
            return;

        Vector3 target = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
        transform.position = Vector3.SmoothDamp(transform.position,target,ref vel, 0.5f);

	}//End Update
}
