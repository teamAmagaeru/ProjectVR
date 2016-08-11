using UnityEngine;
using System.Collections;

public class UIAddScore : MonoBehaviour {

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

    public void SetScore(int value)
    {
        var textMesh = Utility.GetOneComponentInChildren<TextMesh>(transform);
        if (textMesh == null)
        {
            Debug.LogErrorFormat("なんでnullやねん");
            return;
        }
        textMesh.text = Define.UI.addScoreTextLeft + value.ToString() + Define.UI.addScoreTextRight;

        m_anim = Utility.GetOneComponentInChildren<Animation>(transform);
    }
}
