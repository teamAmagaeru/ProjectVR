using UnityEngine;
using System.Collections;

public class NotHtcCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float rotValue = 0.8f;

        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.Rotate(new Vector3(-rotValue, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.Rotate(new Vector3(rotValue, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Rotate(new Vector3(0.0f, -rotValue, 0.0f));
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Rotate(new Vector3(0.0f, rotValue, 0.0f));
        }


    }
}
