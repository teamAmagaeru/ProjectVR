using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RouteManager : ManagerBase
{
	static RouteManager instance
	{
		get {
			return (RouteManager)m_instance;
		}
	}

	protected List<GameObject> m_routeObjList = null;


	/// <summary>
	/// 指定した座標に一番近いルートオブジェクトを取得
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	protected RouteObj GetNearRouteObj(Vector3 pos)
	{
		int index = 0;
		MyMath.CalcNearPos( ref index , pos , instance.m_routeObjList );
		return instance.m_routeObjList[index].GetComponent<RouteObj>();
	}

	/// <summary>
	/// 画面内にあるルートオブジェクトをすべて取得して保持する
	/// </summary>
	protected override void Create()
	{
		//全ルートオブジェクトを取得
		RouteGroup[] route_group_ary = GameObject.FindObjectsOfType<RouteGroup>();
		for( int i = 0 ; i < route_group_ary.Length ; i++ ) {
			List<RouteObj> obj_list = route_group_ary[i].GetRouteObjList();
			for( int j = 0 ; j < obj_list.Count ; j++ ) {
				instance.m_routeObjList.Add( obj_list[j].gameObject );
			}
		}
	}
	protected override void Update()
	{
	}
	protected override void Destroy()
	{
	}
}
