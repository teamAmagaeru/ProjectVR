using UnityEngine;
using System;
using System.Collections;

public class DestroyColijon : MonoBehaviour {

    private float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 0.034)
        {
            Destroy(gameObject);
        }
	}

    //void OnCollisionEnter(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
    //        Debug.DrawRay(contact.point, contact.normal, Color.white);
    //        if (collision.other.gameObject.name.Contains("Sphere") == false)
    //        {
    //            Destroy(collision.other.gameObject);
    //        }
    //    }
    //    Destroy(gameObject);
    //}
}
