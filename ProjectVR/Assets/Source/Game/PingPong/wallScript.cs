using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

    private float boundSpeed = 13;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            contact.otherCollider.GetComponent<Rigidbody>().AddForce(contact.normal * -boundSpeed, ForceMode.Impulse);
        }
    }
}
