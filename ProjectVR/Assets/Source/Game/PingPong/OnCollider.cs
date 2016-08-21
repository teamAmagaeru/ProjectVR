using UnityEngine;
using System.Collections;

public class OnCollider : MonoBehaviour {

    const int boundSpeed_MIN = 2;
    const int boundSpeed_MAX = 4;
    public GameObject boxPut = null;
    private float boundSpeed = 1;

    public GameObject putRoot ;

    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        boundSpeed = UnityEngine.Random.Range(boundSpeed_MIN, boundSpeed_MAX);
        putRoot = GameObject.Find("putRoot");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            contact.otherCollider.GetComponent<Rigidbody>().AddForce(contact.normal * -boundSpeed, ForceMode.Impulse);
        }

    }
    void OnCollisionExit(Collision collision)
    {
        //生成
        GameObject pre = Instantiate(boxPut, gameObject.transform.localPosition, gameObject.transform.localRotation) as GameObject;
        pre.transform.parent = putRoot.transform;
        pre.GetComponent<PutBox>().SetBoundSpeed(boundSpeed);
        pre.layer = LayerMask.NameToLayer("CalcGoal");


        var child_obj_ary = transform.parent.GetComponentsInChildren<Collider>();
        foreach (var child_obj in child_obj_ary)
        {
            child_obj.isTrigger = true;
        }







        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }
}
