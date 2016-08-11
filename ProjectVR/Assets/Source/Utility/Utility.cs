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
    /// <summary>
    /// 子供からコンポーネント取得.
    /// 1つしか存在しないことが保証されている時のみ.
    /// </summary>
    /// <typeparam name="T">取得するコンポーネント</typeparam>
    /// <param name="trans">親</param>
    /// <returns>取得したコンポーネント.失敗時はデフォルト</returns>
    static public T GetOneComponentInChildren<T>(Transform trans)
    {
        T[] compornent = trans.GetComponentsInChildren<T>();
        if (compornent != null && compornent.Length > 0 && compornent[0] != null)
        {
            if (compornent.Length > 1) {
                Debug.LogWarningFormat("コンポーネントが多かったよ");
            }
            return compornent[0];
        }
        Debug.LogErrorFormat("コンポーネントがなかったよ");
        return default(T);
    }

    /// <summary>
    /// レンダラーのenableを変更する.
    /// 子供も全て.
    /// </summary>
    /// <param name="obj">変更したいゲームオブジェクトの親</param>
    /// <param name="enable">enable</param>
    static public void SetRendererEnable(GameObject obj, bool enable)
    {
        var renderer = obj.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = enable;
        }
    }
}
