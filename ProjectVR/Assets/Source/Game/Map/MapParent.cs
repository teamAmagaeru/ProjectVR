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
        switch (m_step) {
            case eStep.ReqLoad:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_stageName, UnityEngine.SceneManagement.LoadSceneMode.Additive);

                m_step = eStep.Load;
                break;
            case eStep.Load:
                {
                    GameObject obj = GameObject.Find("StageParent");
                    if (obj != null)
                    {
                        m_stageParent = obj.GetComponent<StageParent>();
                        obj.transform.parent = transform;
                        m_step = eStep.Update;
                    }
                }
                break;
            case eStep.Update:
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
                break;
        }
    }

    /// <summary>
    /// マップ読み込み.
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void LoadMap(string sceneName)
    {
        UnloadMap();
        m_stageName = sceneName;
        m_step = eStep.ReqLoad;
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
    
    string m_stageName = "";
    StageParent m_stageParent = null;
    enum eStep {
        ReqLoad = 0,    // 読み込みリクエスト.
        Load,           // 読み込み中.
        Update,         // 通常時.
    }
    eStep m_step = eStep.Update;
}
