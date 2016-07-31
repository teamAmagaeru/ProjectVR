using UnityEngine;
using System.Collections;

/// <summary>
/// 時間管理.
/// 拡張したければご自由に.
/// 単位は秒に統一.
/// </summary>
public class TimeCounter {
    public enum eType
    {
        CountDowwn = 0,
        CountUp,

        Num
    }
    eType m_type;

    float m_time;
    public float time {
        get { return m_time; }
    }
    float m_targetTime;

    /// <summary>
    /// どれぐらい進んだか?.
    /// </summary>
    public float rate
    {
        get
        {
            switch (m_type)
            {
                case eType.CountDowwn:
                    return 1.0f - (m_time / m_targetTime);
                case eType.CountUp:
                    return m_time / m_targetTime;
            }
            return 0.0f;
        }
    }
    /// <summary>
    /// カウントスタート.
    /// </summary>
    /// <param name="type">数え方</param>
    /// <param name="time">時間指定</param>
    public TimeCounter(eType type, float time)
    {
        m_type = type;
        m_targetTime = time;
        switch (m_type)
        {
            case eType.CountDowwn:
                m_time = time;
                break;
            case eType.CountUp:
                m_time = 0.0f;
                break;
        }
    }
    /// <summary>
    /// 時間終了?.
    /// </summary>
    /// <returns>true:終了 false:まだ</returns>
    public bool IsEnd()
    {
        switch (m_type)
        {
            case eType.CountDowwn:
                return m_time <= 0.0f;
            case eType.CountUp:
                return m_time >= m_targetTime;
        }
        return false;
    }
    /// <summary>
    /// 毎フレーム呼んでね.
    /// </summary>
    public void Update()
    {
        switch (m_type)
        {
            case eType.CountDowwn:
                m_time -= Time.deltaTime;
                break;
            case eType.CountUp:
                m_time += Time.deltaTime;
                break;
        }
    }
}
