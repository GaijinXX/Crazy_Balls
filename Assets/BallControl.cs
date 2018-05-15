using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnGUI()
    {
        if (GUILayout.Button("Press Me"))
            Debug.Log("Hello!");
    }

    // Update is called once per frame
    void Update () {
        var key = Input.GetAxis("Vertical");

    }
}
