using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// キャラ管理.
/// </summary>
public class CharaManager : ManagerBase{
    static CharaManager instance
    {
        get { return (CharaManager)m_instance; }
    }

    Dictionary<int, CharaBase> m_charaList = null;

    /// <summary>
    /// キャラ追加.
    /// </summary>
    /// <param name="chara">追加したいキャラ</param>
    static public void Add(CharaBase chara)
    {
        if (instance == null)
        {
            return;
        }
        instance.m_charaList.Add(chara.charaId,chara);
    }
    /// <summary>
    /// キャラ削除.
    /// </summary>
    /// <param name="chara">消したいキャラ</param>
    static public void Remove(CharaBase chara)
    {
        if (instance == null)
        {
            return;
        }
        instance.m_charaList.Remove(chara.charaId);
    }

    protected override void Create()
    {
        m_charaList = new Dictionary<int, CharaBase>();
    }
    protected override void Update()
    {
    }
    protected override void Destroy()
    {
    }
}
