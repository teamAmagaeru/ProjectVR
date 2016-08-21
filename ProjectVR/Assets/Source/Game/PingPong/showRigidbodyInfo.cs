using UnityEngine;
using System.Collections;

public class showRigidbodyInfo : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (gameObject.transform.localPosition.y < -30)
        {
            Destroy(gameObject);
        }
    }
    

    public void SetDestroyActive()
    {
        //Debug.Log("SetDestroyActive");
    }


}
