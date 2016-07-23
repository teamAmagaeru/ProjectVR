using UnityEngine;
using System.Collections;

/// <summary>
/// 時間管理.
/// とりあえず減算にしておく.
/// 拡張したければご自由に.
/// 単位は秒に統一.
/// </summary>
public class TimeCounter {
    float m_time;
    public float time {
        get { return m_time; }
    }
    /// <summary>
    /// カウントスタート.
    /// </summary>
    /// <param name="time">時間指定</param>
    public TimeCounter(float time)
    {
        m_time = time;
    }
    /// <summary>
    /// 時間終了?.
    /// </summary>
    /// <returns>true:終了 false:まだ</returns>
    public bool IsEnd()
    {
        return m_time <= 0.0f;
    }
    /// <summary>
    /// 毎フレーム呼んでね.
    /// </summary>
    public void Update()
    {
        m_time -= Time.deltaTime;
    }
}
