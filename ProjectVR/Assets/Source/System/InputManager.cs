using UnityEngine;
using System.Collections;

/// <summary>
/// 入力系のマネージャ.
/// </summary>
public class InputManager
{
    /// <summary>
    /// デバイスの種類.
    /// </summary>
    public enum eDeviceType
    {
        Left = 0,   // 左手.
        Right,      // 右手.
        Hmd,        // 頭.

        Num
    }

    /// <summary>
    /// デバイスの存在確認.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <returns>true:存在する false存在しない</returns>
    static public bool ExistDevice(eDeviceType deviceType)
    {
#if ENABLE_HTC
        if (m_instance == null)
        {
            Debug.LogError("no instance");
            return false;
        }
        GameObject go = GameObject.Find(GetDeviceName(deviceType));
        return GameObject.Find(GetDeviceName(deviceType)) != null;
#else
        return true;
#endif
    }
    /// <summary>
    /// デバイスのTransform取得.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <returns>transform.デバイスが存在しなければnull</returns>
    static public Transform GetTransform(eDeviceType deviceType)
    {
#if ENABLE_HTC
        ViveInput input = GetViveInput(deviceType);
        if (input == null)
        {
            return null;
        }
        return input.transform;
#else
        string name = "";
        switch (deviceType) {
            case eDeviceType.Left:
                name = "LeftDevice";
                break;
            case eDeviceType.Right:
                name = "RightDevice";
                break;
        }
        return GameObject.Find(name).transform;
#endif
    }
    /// <summary>
    /// トリガーを引いた瞬間か?.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <returns>true:引いた瞬間 false:それ以外</returns>
    static public bool IsPullTrigger(eDeviceType deviceType)
    {
#if ENABLE_HTC
        ViveInput input = GetViveInput(deviceType);
        if (input == null)
        {
            return false;
        }
        return input.IsPullTrigger();
#else
        if (NotHtcInput.isDeviceMatch(deviceType)){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                return true;
            }
        }
        return false;
#endif
    }
    /// <summary>
    /// タッチパッドを押しているか?.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <returns>true:押している false:離している</returns>
    static public bool IsPressTouchpad(eDeviceType deviceType)
    {
#if ENABLE_HTC
        ViveInput input = GetViveInput(deviceType);
        if (input == null)
        {
            return false;
        }
        return input.IsPressTouchpad();
#else
        if (NotHtcInput.isDeviceMatch(deviceType)){
            if (Input.GetKey(KeyCode.Z))
            {
                return true;
            }
        }
        return false;
#endif
    }
    /// <summary>
    /// コントローラーを振動させる.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <param name="time">振動時間(sec)</param>
    /// <param name="value">振動値.最大3999だが、100～2000辺りが有効範囲らしい</param>
    static public void TriggerHapticPulse(eDeviceType deviceType, ushort value,float time)
    {
#if ENABLE_HTC
        ViveInput input = GetViveInput(deviceType);
        if (input == null)
        {
            return;
        }
        input.TriggerHapticPulse(value,time);
#else
        Debug.Log("バイブ!!");
#endif

    }


#region local //-----------------------------ここから先は外部から見る必要なし-----------------------------//
    /// <summary>
    /// マウスボタンの種類.
    /// </summary>
    public enum MouseButton
    {
        Left = 0,
        Right,
        Middle,

        Num
    };

    static string[] m_deviceName = new string[(int)eDeviceType.Num] {
        "Controller (left)",
        "Controller (right)",
        "Camera (head)"
    };
    static string GetDeviceName(eDeviceType type)
    {
        return m_deviceName[(int)type];
    }

    Vector3? m_oldPos = null;
    Vector3? m_oldOldPos = null;


    static public void SysCreate()
    {
        if (m_instance == null)
        {
            m_instance = new InputManager();
        }
        m_instance.Create();
    }
    static public void SysUpdate()
    {
        if (m_instance != null)
        {
            m_instance.Update();
        }
    }
    static public void SysDestroy()
    {
        if (m_instance != null)
        {
            m_instance.Destroy();
        }
        m_instance = null;
    }
    protected static InputManager m_instance = null;
    static public InputManager instance
    {
        get
        {
            return m_instance;
        }
    }

    protected void Create()
    {
    }
    protected void Update()
    {
        m_oldOldPos = m_oldPos;
        // マウスボタンが押されたタイミングで、マウスの位置を保存する.
        if (Input.GetMouseButton((int)MouseButton.Left) ||
        Input.GetMouseButton((int)MouseButton.Right) ||
        Input.GetMouseButton((int)MouseButton.Middle))
        {
            m_oldPos = Input.mousePosition;
        }
        else
        {
            m_oldPos = null;
        }
    }
    protected void Destroy()
    {
    }

    static public Vector3 GetMove(MouseButton button)
    {
        if (instance == null)
        {
            return Vector3.zero;
        }
        if (instance.m_oldOldPos == null)
        {
            return Vector3.zero;
        }
        if (Input.GetMouseButton((int)button) == false)
        {
            return Vector3.zero;
        }
        return Input.mousePosition - instance.m_oldOldPos.GetValueOrDefault();
    }
    static public float GetWheel()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }


    /// <summary>
    /// inputクラス取得.
    /// </summary>
    /// <param name="deviceType">デバイスのタイプ</param>
    /// <returns>inputクラス.存在しなければnull</returns>
    static ViveInput GetViveInput(eDeviceType deviceType)
    {
        if (m_instance == null)
        {
            Debug.LogError("no instance");
            return null;
        }
        GameObject parent = GameObject.Find(GetDeviceName(deviceType));
        if (parent == null)
        {
            return null;
        }

        return parent.GetComponent<ViveInput>();
    }

#endregion

}
