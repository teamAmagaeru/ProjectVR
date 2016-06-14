using UnityEngine;
using System.Collections;

/// <summary>
/// 入力系のマネージャ.
/// </summary>
public class InputManager
{
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
        get {
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
}
