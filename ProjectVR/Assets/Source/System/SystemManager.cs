using UnityEngine;
using System.Collections;

public class SystemManager : MonoBehaviour {
    void Awake()
    {
        LoadCameraScene();
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start ()
    {
    }

    string sceneName =
#if ENABLE_HTC
        "htcCamera";
#else
        "notHtcCamera";
#endif


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
                ++m_step;
                break;
            case eStep.InitWait:
                ++m_step;
                break;
            case eStep.Update:
                CharaManager.SysUpdate();
                InputManager.SysUpdate();
                if (InputManager.IsPullTrigger(InputManager.eDeviceType.Left))
                {
                    InputManager.TriggerHapticPulse(InputManager.eDeviceType.Left, 1000, 0.1f);
                    Debug.Log("left trigger");
                }
                if (InputManager.IsPullTrigger(InputManager.eDeviceType.Right))
                {
                    InputManager.TriggerHapticPulse(InputManager.eDeviceType.Right, 1000, 0.1f);
                    Debug.Log("right trigger");
                }
                if (InputManager.ExistDevice(InputManager.eDeviceType.Left))
                {
 //                   Debug.Log("pos = " + InputManager.GetTransform(InputManager.eDeviceType.Left).position);
                }
                if (InputManager.ExistDevice(InputManager.eDeviceType.Right)) {
//                    Debug.Log("pos = " + InputManager.GetTransform(InputManager.eDeviceType.Right).position);
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    ChangeScene("stageSelect");
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
    static public T Create<T>(string prefabName)
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
    static string m_currentSceneName = "initialize";

    /// <summary>
    /// シーン読み込み.
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    static public void ChangeScene(string sceneName)
    {
        if (m_currentSceneName != "")
        {
            UnityEngine.SceneManagement.SceneManager.UnloadScene(m_currentSceneName);
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    void LoadCameraScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
