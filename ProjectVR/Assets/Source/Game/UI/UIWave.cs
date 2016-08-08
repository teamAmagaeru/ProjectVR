using UnityEngine;
using System.Collections;

/// <summary>
/// wave管理.
/// </summary>
public class UIWave : MonoBehaviour {
    Animation m_anim = null;
    bool m_isAppear = false;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        if (m_isAppear)
        {
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
	}

    public void AppearWave(int wave)
    {
        TextMesh[] textMesh = transform.GetComponentsInChildren<TextMesh>();
        if (textMesh != null && textMesh.Length>0 && textMesh[0] != null)
        {
            textMesh[0].text = "wave " + wave;
        }
        if (m_anim == null)
        {
            Animation[] anims = transform.GetComponentsInChildren<Animation>();
            if (anims != null && anims.Length > 0 && anims[0] != null)
            {
                m_anim = anims[0];
            }
        }
        if (m_anim != null)
        {
            m_anim.Play("levelUpAnimation");
        }
        else
        {
            Debug.LogErrorFormat("なんでanimないねん");
        }
        m_isAppear = true;
    }
}
