using UnityEngine;
using System.Collections;

public class UIScore : MonoBehaviour {
    TextMesh m_text = null;
    void Awake()
    {
        m_text = Utility.GetOneComponentInChildren<TextMesh>(transform);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetScore(int value)
    {
        if (m_text == null)
        {
            m_text = Utility.GetOneComponentInChildren<TextMesh>(transform);
        }
        if (m_text == null)
        {
            Debug.LogErrorFormat("なんでnullやねん");
            return;
        }
        m_text.text = value.ToString();
    }
}
