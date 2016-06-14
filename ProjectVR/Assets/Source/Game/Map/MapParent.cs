using UnityEngine;
using System.Collections;

/// <summary>
/// マップ関連の親.今のところ一番の大元.
/// </summary>
public class MapParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_stageParent==null && m_isReqLoadMap)
        {
            GameObject obj = GameObject.Find("StageParent");
            if (obj != null)
            {
                m_stageParent = obj.GetComponent<StageParent>();
                m_isReqLoadMap = false;
                obj.transform.parent = transform;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 pos = transform.position;
            pos.y += 1.0f;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = transform.position;
            pos.y -= 1.0f;
            transform.position = pos;
        }
    }

    /// <summary>
    /// マップ読み込み.
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void LoadMap(string sceneName)
    {
        m_stageName = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_stageName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        m_isReqLoadMap = true;
    }
    /// <summary>
    /// マップ解放.
    /// </summary>
    public void UnloadMap()
    {
        if (m_stageName != "")
        {
            GameObject.Destroy(m_stageParent.gameObject);
            m_stageParent = null;
            UnityEngine.SceneManagement.SceneManager.UnloadScene(m_stageName);
        }
    }

    bool m_isReqLoadMap = false;
    string m_stageName = "";
    StageParent m_stageParent = null;
}
