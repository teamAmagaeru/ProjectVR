using UnityEngine;
using System.Collections;

public class PutBox : MonoBehaviour
{
    private float boundSpeed = 8;

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //gameObject.GetComponent<Animation>().Play();
        foreach (ContactPoint contact in collision.contacts)
        {
            //contact.otherCollider.GetComponent<Rigidbody>().AddForce(contact.normal * -boundSpeed, ForceMode.Impulse);
        }
    }

    public void SetBoundSpeed(float speed)
    {
        boundSpeed = speed;
    }
}