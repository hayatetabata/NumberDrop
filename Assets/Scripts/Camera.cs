using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject __player;
    Vector3 __offset;

	// Use this for initialization
	void Start () {
        __offset = transform.position - __player.transform.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        try {
            Vector3 pos = __player.transform.position;
            pos.x = 0f;
            transform.position = pos + __offset;
        } catch (MissingReferenceException e) {
            if (e.Message.Contains("The object of type 'GameObject'")) {
                Debug.Log("Player has already been destroyed.");
                return;
            }
            throw e;
        }
	}
}
