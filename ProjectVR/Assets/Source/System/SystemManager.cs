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
                UIManager.SysCreate();

                ChangeScene("pingpong");
                ++m_step;
                break;
            case eStep.InitWait:
                ++m_step;
                break;
            case eStep.Update:
                CharaManager.SysUpdate();
                InputManager.SysUpdate();
                UIManager.SysUpdate();
                if (InputManager.IsPullTrigger(InputManager.eDeviceType.Left))
                {
                    InputManager.TriggerHapticPulse(InputManager.eDeviceType.Left, Define.Controller.ShootVibrationValue, Define.Controller.ShootVibrationTime);
                    Debug.Log("left trigger");
                }
                if (InputManager.IsPullTrigger(InputManager.eDeviceType.Right))
                {
                    InputManager.TriggerHapticPulse(InputManager.eDeviceType.Right, Define.Controller.ShootVibrationValue, Define.Controller.ShootVibrationTime);
                    Debug.Log("right trigger");
                }
                if (InputManager.IsPressTouchpad(InputManager.eDeviceType.Left))
                {
//                    Debug.Log("left press touchpad");
                }
                if (InputManager.IsPressTouchpad(InputManager.eDeviceType.Right))
                {
//                    Debug.Log("right press touchpad");
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
//                    ChangeScene("stageSelect");
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
//                    ChangeScene("pingpong");
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    UIManager.AppearWave(10);
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    UIManager.EnableScore(m_score);
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    UIManager.DisableScore();
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    m_score += 100;
                    UIManager.SetScore(m_score);
                    UIManager.AppearAddScore(100);
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    UIManager.AppearShootResult(0);
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    UIManager.AppearShootResult(1);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    UIManager.AppearShootResult(2);
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    UIManager.AppearShootResult(3);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    UIManager.AppearShootResult(4);
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    UIManager.AppearShootResult(5);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    UIManager.EnableOutOfRangeAlert();
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    UIManager.DisableOutOfRangeAlert();
                }
                break;
        }
	}
    int m_numBullet = 20;
    int m_score = 1000;
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
