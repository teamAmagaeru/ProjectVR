using UnityEngine;
using System.Collections;

public class CharaBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    int m_charaId = 0;
    public int charaId {
        get { return m_charaId; }
    }
}
