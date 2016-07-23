using UnityEngine;
using System.Collections;

public class NotHtcInput : MonoBehaviour {

    InputManager.eDeviceType m_deviceType;
	// Use this for initialization
	void Start () {
        if (gameObject.name == "LeftDevice")
        {
            m_deviceType = InputManager.eDeviceType.Left;
        }
        if (gameObject.name == "RightDevice")
        {
            m_deviceType = InputManager.eDeviceType.Right;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isDeviceMatch(m_deviceType) == false)
        {
            return;
        }
        float rotValue = 0.8f;
        float moveValue = 0.01f;
        // Ctrlが押されていたら回転.
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(new Vector3(-rotValue, 0.0f, 0.0f));
            }
            if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.S))
            {
                transform.Rotate(new Vector3(rotValue, 0.0f, 0.0f));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0.0f, -rotValue, 0.0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0.0f, rotValue, 0.0f));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, -rotValue));
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(0.0f, 0.0f , rotValue));
            }
        }
        else
        {
            Vector3 pos = transform.localPosition;
            if (Input.GetKey(KeyCode.W))
            {
                pos.y += moveValue;
            }
            if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.S))
            {
                pos.y -= moveValue;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= moveValue;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += moveValue;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                pos.z -= moveValue;
            }
            if (Input.GetKey(KeyCode.E))
            {
                pos.z += moveValue;
            }
            transform.localPosition = pos;
        }
    }
    public static bool isDeviceMatch(InputManager.eDeviceType deviceType)
    {
        switch (deviceType)
        {
            case InputManager.eDeviceType.Left:
                return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            case InputManager.eDeviceType.Right:
                return Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.RightShift) == false;
        }
        return false;
    }
}
