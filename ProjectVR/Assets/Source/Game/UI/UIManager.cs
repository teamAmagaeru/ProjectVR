using UnityEngine;
using System.Collections;

/// <summary>
/// UI関係の管理.
/// </summary>
public class UIManager {

    /// <summary>
    /// 残段数表示.
    /// </summary>
    /// <param name="num">開始時の数</param>
    public static void EnableNumBullet(int num)
    {
        if (numBullets == null)
        {
            return;
        }
        if (InputManager.ExistDevice(InputManager.eDeviceType.Left))
        {
            var t = Utility.Create<UINumBullet>("Prefab/UI/NumBullet");
            t.SetNumBullet(num);
            Utility.SetParent(InputManager.GetTransform(InputManager.eDeviceType.Left), t.transform);
            numBullets[0] = t;
        }
        if (InputManager.ExistDevice(InputManager.eDeviceType.Right))
        {
            var t = Utility.Create<UINumBullet>("Prefab/UI/NumBullet");
            t.SetNumBullet(num);
            Utility.SetParent(InputManager.GetTransform(InputManager.eDeviceType.Right), t.transform);
            numBullets[1] = t;
        }
    }
    /// <summary>
    /// 残段数非表示.
    /// </summary>
    public static void DisableNumBullet()
    {
        if (numBullets == null)
        {
            return;
        }
        for (int i = 0; i < numBullets.Length; ++i)
        {
            if (numBullets[i] == null)
            {
                continue;
            }
            GameObject.Destroy(numBullets[i].gameObject);
            numBullets[i] = null;
        }
    }
    /// <summary>
    /// 残段数をセット.
    /// </summary>
    /// <param name="num">残段数</param>
    public static void SetNumBullet(int num)
    {
        if (numBullets == null)
        {
            return;
        }
        foreach (var b in numBullets)
        {
            if (b == null)
            {
                continue;
            }
            b.SetNumBullet(num);
        }
    }

    /// <summary>
    /// waveを表示.
    /// </summary>
    /// <param name="value">表示したいwave</param>
    public static void AppearWave(int value)
    {
        UIWave wave = Utility.Create<UIWave>("Prefab/UI/3DText/levelNow");
        Utility.SetParent(InputManager.GetTransform(InputManager.eDeviceType.Hmd), wave.transform);
        wave.AppearWave(value);
    }

    /// <summary>
    /// スコア表示.
    /// </summary>
    /// <param name="value">開始時の点数</param>
    public static void EnableScore(int value)
    {

    }
    /// <summary>
    /// スコア非表示.
    /// </summary>
    public static void DisableScore(int value)
    {

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
        // prefab読み込みに変更.
//        outOfRange.Enable();
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
        // prefab削除に変更.
//        outOfRange.Disable();
    }



#region //--------------------登録とか--------------------//
    UINumBullet[] m_numBullets = new UINumBullet[2];
    public static UINumBullet[] numBullets
    {
        get
        {
            if (m_instance == null)
            {
                return null;
            }
            return m_instance.m_numBullets;
        }
        set
        {
            if (m_instance == null)
            {
                return;
            }
            m_instance.m_numBullets = value;
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
    GameObject m_outOfRange = null;
    public static GameObject outOfRange
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
