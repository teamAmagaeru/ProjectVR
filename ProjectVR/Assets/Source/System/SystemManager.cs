using UnityEngine;
using System.Collections;

public class SystemManager : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
	
	}
	
    enum eStep {
        Init = 0,
        InitWait,
        Update
    }
    eStep m_step = eStep.Init;

    MapParent m_mapParent = null;
    HandRay m_ray = null;

	// Update is called once per frame
	void Update () {
        switch (m_step)
        {
            case eStep.Init:
                CharaManager.SysCreate();
                InputManager.SysCreate();
                // マップクラス作成.
                if (m_mapParent == null)
                {
                    m_mapParent = Create<MapParent>("Prefab/Map/MapParent");
                }
                // レイ.
                if (m_ray == null)
                {
                    m_ray = Create<HandRay>("Prefab/HandRay");
                }
                ++m_step;
                break;
            case eStep.InitWait:
                ++m_step;
                break;
            case eStep.Update:
                CharaManager.SysUpdate();
                InputManager.SysUpdate();
                if (m_mapParent != null)
                {
                    if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
                    {
                        m_mapParent.LoadMap("stage00_00");
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        m_mapParent.LoadMap("stage00_01");
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        m_mapParent.UnloadMap();
                    }
                }
                break;
        }
	}
    
    /// <summary>
    /// クラス生成.
    /// </summary>
    /// <typeparam name="T">生成したいクラス(GetComopnentするだけ)</typeparam>
    /// <param name="prefabName">プレハブの名前</param>
    /// <returns></returns>
    T Create<T>(string prefabName)
    {
        Object obj = Instantiate(Resources.Load(prefabName));
        if (obj != null)
        {
            GameObject go = obj as GameObject;
            if (go != null)
            {
                return go.GetComponent<T>();
            }
        }
        return default(T);
    }
}
