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


	// Update is called once per frame
	void Update () {
        switch (m_step)
        {
            case eStep.Init:
                CharaManager.SysCreate();
                break;
            case eStep.InitWait:
                break;
            case eStep.Update:
                CharaManager.SysUpdate();
                break;
        }
	}
}
