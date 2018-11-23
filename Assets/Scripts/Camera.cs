using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject __player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        try {
            Vector3 pos = transform.position;
            pos.y = __player.transform.position.y +2f;
            transform.position = pos;
        } catch (MissingReferenceException e) {
            if (e.Message.Contains("The object of type 'GameObject'")) {
                Debug.Log("Player has already been destroyed.");
                return;
            }
            throw e;
        }
	}
}
