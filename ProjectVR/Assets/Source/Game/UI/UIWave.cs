using UnityEngine;
using System.Collections;

/// <summary>
/// wave管理.
/// </summary>
public class UIWave : MonoBehaviour {
    Animation m_anim = null;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        if (m_anim == null)
        {
            Debug.LogErrorFormat("なんでanimないねん");
            return;
        }
        if (m_anim.isPlaying)
        {
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
	}

    public void AppearWave(int wave)
    {
        TextMesh[] textMesh = transform.GetComponentsInChildren<TextMesh>();
        if (textMesh == null)
        {
            Debug.LogErrorFormat("なんでnullやねん");
            return;
        }
        if (textMesh != null && textMesh.Length>0 && textMesh[0] != null)
        {
            textMesh[0].text = Define.UI.waveTextLeft + wave + Define.UI.waveTextRight;
        }
        m_anim = Utility.GetOneComponentInChildren<Animation>(transform);
    }
}
