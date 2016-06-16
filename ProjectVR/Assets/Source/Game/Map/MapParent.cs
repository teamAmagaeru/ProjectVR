using UnityEngine;
using System.Collections;

/// <summary>
/// マップ関連の親.今のところ一番の大元.
/// </summary>
public class MapParent : MonoBehaviour {

    float[] m_scaleTable = new float[]
    {
        0.1f,
        0.5f,
        1.0f,
        2.0f,
        4.0f,
        8.0f,
    };
    int m_scaleIndex = 2;
    
    float m_wheel = 0.0f;

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

            float wheel = InputManager.GetWheel();
            // 普通に線形.
            {
                Vector3 middle = InputManager.GetMove(InputManager.MouseButton.Middle);
                {
                    Vector3 pos = transform.position;
                    pos.x += middle.x * 0.1f;
                    pos.y += middle.y * 0.1f;
                    transform.position = pos;
                }
                transform.localScale *= 1.0f + wheel;
            }
            // iTween.
            {
                bool isChange = false;
                bool isSmall = false;
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    isChange = true;
                    isSmall = false;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    isChange = true;
                    isSmall = true;
                }
                if (isChange){
                    var hash = new Hashtable();
                    //        moveHash."
                    float smallValue = 0.5f;
                    float bigValue = 2.0f;
                    Vector3 smallVec = new Vector3(smallValue, smallValue, smallValue);
                    Vector3 bigVec = new Vector3(bigValue, bigValue, bigValue);
                    /*
                    if (isSmall)
                    {
                        hash.Add("scale", smallVec);
                    }
                    else
                    {
                        hash.Add("scale", bigVec);
                    }
                    hash.Add("time", 2.0f);
                    hash.Add("delay", 1.0f);
                    hash.Add("easeType", "easeInOutBack");
                    iTween.MoveTo(this.gameObject, hash);
                    */
                    float value = 0.0f;
                    /*
                    if (isSmall) {
                        value = transform.localScale.x * smallValue;
                    } else
                    {
                        value = transform.localScale.x * bigValue;
                    }
                    */
                    if (isSmall)
                    {
                        --m_scaleIndex;
                        m_scaleIndex = Mathf.Max(0, m_scaleIndex);
                    }
                    else
                    {
                        ++m_scaleIndex;
                        m_scaleIndex = Mathf.Min(m_scaleTable.Length-1, m_scaleIndex);
                    }
                    value = m_scaleTable[m_scaleIndex];

                    hash.Add("x", value);
                    hash.Add("y", value);
                    hash.Add("z", value);
//                    hash.Add("delay", 0.5f);
                    hash.Add("time", 1.0f);
//                    hash.Add("easetype", "spring");
                    iTween.ScaleTo(gameObject, hash);

                    m_wheel = 0.0f;
                }
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
