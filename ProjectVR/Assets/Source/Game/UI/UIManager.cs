using UnityEngine;
using System.Collections;

/// <summary>
/// UI関係の管理.
/// </summary>
public class UIManager {

    /// <summary>
    /// waveを表示.
    /// </summary>
    /// <param name="wave">表示したいwave</param>
    public static void AppearWave(int wave)
    {
        if (m_instance == null)
        {
            return;
        }
        if (m_instance.m_wave == null)
        {
            return;
        }
        m_instance.m_wave.AppearWave(wave);
    }
    public static void RegistWave(UIWave obj)
    {
        if (m_instance == null)
        {
            return;
        }
        m_instance.m_wave = obj;
    }
    UIWave m_wave = null;

    #region local //-----------------------------ここから先は外部から見る必要なし-----------------------------//
    static public void SysCreate()
    {
        if (m_instance == null)
        {
            m_instance = new UIManager();
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
    protected static UIManager m_instance = null;
    static public UIManager instance
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
    }
    protected void Destroy()
    {
    }
#endregion
}
