using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        //Physics.bounceThreshold = 0.0000001f;

        Physics.gravity = new Vector3(0, -20.0F, 0);
        rb = GetComponent<Rigidbody>();

    }

    void OnGUI()
    {
        //if (GUILayout.Button("Press Me"))
        //    Debug.Log("Hello!");
    }

    // Update is called once per frame
    void Update () {
        var key = Input.GetAxis("Vertical");
        string a = Input.inputString;
        //if(a.Length > 0)
        //    Debug.Log(a);


    }
}
