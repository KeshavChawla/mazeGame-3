using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	private bool walking = false;
	private Vector3 spawnPoint;
	// Use this for initialization
	void Start () { // Same as OnClip (Load) 
		spawnPoint = transform.position;  // Set variable transform.position to initial point
	}


	void Update () {  // Same as OnClip (Enterframe) - Update is called once per frame

		if (walking) { // If Walking then
			transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime; //Current position move the camera by .5 per each frame and continuously 
		}

		if (transform.position.y < -10f) { // If y position is - 10 which also means fall of the map
			transform.position = spawnPoint; // Return back to initial on load point
		}
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit; 

		if (Physics.Raycast (ray, out hit)) { // Collider is the camera in the perspective of the person
			if (hit.collider.name.Contains ("plane")) { // If View Ray or Camera hit Collider then (looks down)
				walking = false; // Stop Walking
			} else {
				walking = true; // Keep Walking
			}
		}
	}
}
