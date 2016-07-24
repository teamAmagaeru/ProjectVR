using UnityEngine;
using System.Collections;

public class StageSelectObj : MonoBehaviour {

    TextMesh m_textMesh = null;
    string m_text = "";
	// Use this for initialization
	void Start () {
        GameObject child = transform.FindChild("Text").gameObject;
        m_textMesh = child.GetComponent<TextMesh>();
	}

    // Update is called once per frame
    void Update()
    {
        if (m_textMesh != null)
        {
            m_textMesh.text = m_text;
        }
    }

    /// <summary>
    /// テキスト変更.
    /// ステージID指定バージョン.
    /// </summary>
    /// <param name="stageId">ステージID指定</param>
    public void ChangeText(int stageId)
    {
        ChangeText("Stage " + stageId);
    }
    /// <summary>
    /// テキスト変更
    /// </summary>
    /// <param name="text">表示したいテキスト</param>
    public void ChangeText(string text)
    {
        m_text = text;
    }
}
