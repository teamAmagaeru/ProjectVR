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

	// Update is called once per frame
	void Update () {
        switch (m_step)
        {
            case eStep.Init:
                CharaManager.SysCreate();
                InputManager.SysCreate();
                // マップクラス作成.
                CreateMap();
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
    /// マップクラス作成.
    /// </summary>
    void CreateMap()
    {
        if (m_mapParent == null)
        {
            Object obj = Instantiate(Resources.Load("Prefab/Map/MapParent"));
            if (obj != null)
            {
                GameObject go = obj as GameObject;
                if (go != null)
                {
                    m_mapParent = go.GetComponent<MapParent>();
                }
            }
        }
    }
}
