using UnityEngine;
using System.Collections;

/// <summary>
/// UI関係の管理.
/// </summary>
public class UIManager {

    /// <summary>
    /// 残段数をセット.
    /// </summary>
    /// <param name="num">残段数</param>
    public static void SetNumBullet(int num)
    {
    }
    
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

    /// <summary>
    /// スコアをセット.
    /// </summary>
    /// <param name="score">現在のスコア</param>
    public static void SetScore(int score)
    {
    }
    /// <summary>
    /// 追加点を表示.
    /// </summary>
    /// <param name="score">追加点</param>
    public static void AppearAddScore(int score)
    {
    }

    /// <summary>
    /// シュートを決めた時の評価を表示.
    /// </summary>
    /// <param name="numBound">バウンド回数</param>
    public static void AppearShootResult(int numBound)
    {
    }

    /// <summary>
    /// 投げていい所定範囲を出てしまった場合のアラート表示.
    /// </summary>
    public static void AppearOutOfRangeAlert()
    {

    }



    #region //--------------------登録とか--------------------//
    public static void RegistWave(UIWave obj)
    {
        if (m_instance == null)
        {
            return;
        }
        m_instance.m_wave = obj;
    }
    UIWave m_wave = null;
#endregion
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
