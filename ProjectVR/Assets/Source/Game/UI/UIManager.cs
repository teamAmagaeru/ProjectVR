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
        if (numBullet == null)
        {
            return;
        }
        numBullet.SetNumBullet(num);
    }

    /// <summary>
    /// waveを表示.
    /// </summary>
    /// <param name="value">表示したいwave</param>
    public static void AppearWave(int value)
    {
        if (wave == null)
        {
            return;
        }
        wave.AppearWave(value);
    }

    /// <summary>
    /// スコアをセット.
    /// </summary>
    /// <param name="value">現在のスコア</param>
    public static void SetScore(int value)
    {
        if (score == null)
        {
            return;
        }
        score.SetScore(value);
    }
    /// <summary>
    /// 追加点を表示.
    /// </summary>
    /// <param name="value">追加点</param>
    public static void AppearAddScore(int value)
    {
        if (addScore == null)
        {
            return;
        }
        addScore.AddScore(value);
    }

    /// <summary>
    /// シュートを決めた時の評価を表示.
    /// </summary>
    /// <param name="numBound">バウンド回数</param>
    public static void AppearShootResult(int numBound)
    {
        if (shootResult == null)
        {
            return;
        }
        shootResult.SetResult(numBound);
    }

    /// <summary>
    /// 投げていい所定範囲を出てしまった場合のアラート表示.
    /// </summary>
    public static void EnableOutOfRangeAlert()
    {
        if (outOfRange == null)
        {
            return;
        }
        outOfRange.Enable();
    }
    /// <summary>
    /// 投げていい所定範囲を出てしまった場合のアラート非表示.
    /// </summary>
    public static void DisableOutOfRangeAlert()
    {
        if (outOfRange == null)
        {
            return;
        }
        outOfRange.Disable();
    }



    #region //--------------------登録とか--------------------//
    UINumBullet m_numBullet = null;
    public static UINumBullet numBullet
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_numBullet;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_numBullet = value;
        }
    }
    UIWave m_wave = null;
    public static UIWave wave
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_wave;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_wave = value;
        }
    }
    UIScore m_score = null;
    public static UIScore score
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_score;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_score = value;
        }
    }
    UIAddScore m_addScore = null;
    public static UIAddScore addScore
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_addScore;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_addScore = value;
        }
    }
    UIShootResult m_shootResult = null;
    public static UIShootResult shootResult
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_shootResult;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_shootResult = value;
        }
    }
    UIOutOfRange m_outOfRange = null;
    public static UIOutOfRange outOfRange
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_outOfRange;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_outOfRange = value;
        }
    }
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
