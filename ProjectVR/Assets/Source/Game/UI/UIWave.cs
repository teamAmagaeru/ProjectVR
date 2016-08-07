using UnityEngine;
using System.Collections;

/// <summary>
/// wave管理.
/// </summary>
public class UIWave : MonoBehaviour {

    TextMesh m_textMesh = null;
	// Use this for initialization
	void Start () {
        UIManager.RegistWave(this);
        m_textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AppearWave(int wave)
    {
        if (m_textMesh == null)
        {
            m_textMesh.text = "wave " + wave;
        }
        // TODO : アニメーション制御は後で.
    }
}
