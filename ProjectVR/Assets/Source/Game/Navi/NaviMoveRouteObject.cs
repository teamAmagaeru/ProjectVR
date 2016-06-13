using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NaviMoveRouteObject : NaviMoveObject
{
	/// <summary>
	/// ステートを戻した時にもとのルートに戻れるように今は保持
	/// そのうち担当エリアのＩＤを保持して、そこからルートを取得するように変えるかも
	/// </summary>
	protected Route m_route = null;

	protected override void Awake()
	{
		base.Awake();

		if( this.m_route == null ) {
			this.m_route = new Route( Route.eMoveType.OrderAsc );
			this.m_route.AddRoutePos( new Vector3( 4f , transform.position.y , 2f ));
			this.m_route.AddRoutePos( new Vector3( -4f , transform.position.y , 3f ));
			this.m_route.AddRoutePos( new Vector3( 3f , transform.position.y , -3f ));
			this.m_route.AddRoutePos( new Vector3( -2f , transform.position.y , -1f ) );
			this.m_route.CalcNearRoutePos(this.transform.position);
			this.SetDestination( this.m_route.GetNowRoutePos() );
		}
		m_state = new NaviStateMoveRoute( this , this.m_route );
	}
	// Update is called once per frame
	void Update () {
		m_state.Action();
	}

}
