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
                        obj.transform.localPosition = Vector3.zero;
                        obj.transform.localScale = Vector3.one;
                        obj.transform.localRotation = new Quaternion();
                        m_step = eStep.Update;
                    }
                }
                break;
            case eStep.Update:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    transform.localRotation = new Quaternion();
                }
                Vector3 right = InputManager.GetMove(InputManager.MouseButton.Right);
                transform.Rotate(right.y * 0.1f, -right.x * 0.1f, 0.0f);
                Vector3 left = InputManager.GetMove(InputManager.MouseButton.Left);
                {
                    Vector3 pos = transform.position;
                    pos.x += left.x * 0.1f;
                    pos.y += left.y * 0.1f;
                    transform.position = pos;
                }
                float wheel = InputManager.GetWheel();
                transform.localScale *= 1.0f + wheel;
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
        if (m_stageParent != null)
        {
            GameObject.Destroy(m_stageParent.gameObject);
            m_stageParent = null;
        }
        if (m_stageName != "")
        {
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
