using UnityEngine;
using System.Collections;

public class Utility {

    /// <summary>
    /// クラス生成.
    /// </summary>
    /// <typeparam name="T">生成したいクラス(GetComopnentするだけ)</typeparam>
    /// <param name="prefabName">プレハブの名前</param>
    /// <returns></returns>
    static public T Create<T>(string prefabName)
    {
        Object loadObj = Resources.Load(prefabName);
        if (loadObj == null)
        {
            Debug.LogErrorFormat("生成に失敗 prefabName = {0}", prefabName);
            return default(T);
        }
        Object obj = GameObject.Instantiate(loadObj);
        if (obj != null)
        {
            GameObject go = obj as GameObject;
            if (go != null)
            {
                return go.GetComponent<T>();
            }
        }
        return default(T);
    }
    /// <summary>
    /// 親子設定し、座標などを初期化.
    /// </summary>
    /// <param name="parent">親</param>
    /// <param name="child">子供</param>
    static public void SetParent(Transform parent, Transform child)
    {
        child.parent = parent;
        child.localPosition = Vector3.zero;
        child.localRotation = Quaternion.identity;
        child.localScale = Vector3.one;
    }
}
