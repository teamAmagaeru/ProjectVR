using UnityEngine;
using System.Collections;

/// <summary>
/// マネージャの基底.
/// 派生クラスはstatic関数を実装し、m_instanceのnullチェックを行うこと.
/// </summary>
public class ManagerBase {

   protected  static ManagerBase m_instance = null;

   static  public void SysCreate()
    {
        if (m_instance == null)
        {
            m_instance = new ManagerBase();
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

    protected virtual void Create()
    {
    }
    protected virtual void Update()
    {
    }
    protected virtual void Destroy()
    {
    }


}
