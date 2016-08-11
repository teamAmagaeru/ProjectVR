using UnityEngine;
using System.Collections;

public class UIShootResult : MonoBehaviour {

    Animation m_anim = null;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
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

    public void SetResult(int numBound)
    {
        var textMesh = Utility.GetOneComponentInChildren<TextMesh>(transform);
        if (textMesh == null)
        {
            Debug.LogErrorFormat("なんでnullやねん");
            return;
        }
        Define.UI.ShootResult result = Define.UI.shootResults[0];
        foreach (var d in Define.UI.shootResults)
        {
            if (d.bound > numBound)
            {
                break;
            }
            result = d;
        }
        textMesh.text = result.text;
        textMesh.color = result.color;

        m_anim = Utility.GetOneComponentInChildren<Animation>(transform);
    }
}
