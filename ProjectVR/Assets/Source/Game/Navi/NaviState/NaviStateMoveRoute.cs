using UnityEngine;
using System.Collections;

public class NaviStateMoveRoute : NaviState
{
	protected Route m_route = null;

	public NaviStateMoveRoute( NaviMoveObject naviMoveObj , Route route )
		: base( naviMoveObj )
	{
		this.m_route = route;
	}

	override public void Action()
	{
		if( this.m_route.GetRouteCount() != 0 &&
			this.m_naviMoveObj.IsStandOnTargetPos( this.m_route.GetNowRoutePos() )
		) {
			this.ChangeToNextTarget();
		}
	}

	/// <summary>
	/// 次の目的地を設定
	/// </summary>
	protected void ChangeToNextTarget()
	{
		if( this.m_route == null ) {
			return;
		}
		//次の座標のインデックスを計算
		this.m_route.CalcNextTargetIndex();
		//次の座標をナビゲーションに設定
		this.m_naviMoveObj.SetDestination( this.m_route.GetNowRoutePos() );
	}
}
