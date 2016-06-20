using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// ルートオブジェクトのグループクラス
/// 
/// </summary>
public class RouteGroup : MonoBehaviour {

	[SerializeField]
	protected List<RouteObj> m_routeObjList = null;
	protected Route m_route = new Route();

	// Use this for initialization
	void Awake() {
		for( int i = 0 ;  i < m_routeObjList.Count ; i++ ) {
			m_route.AddRoutePos( m_routeObjList[i].transform.position );
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public List<RouteObj> GetRouteObjList()
	{
		return this.m_routeObjList;
	}


	public Route GetRoute()
	{
		return this.m_route;
	}

}
