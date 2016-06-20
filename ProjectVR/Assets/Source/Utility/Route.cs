using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Route
{
	public enum eMoveType
	{
		OrderAsc,   //順番
		OrderDesc,  //逆順
		Random      //ランダム
	};
	protected List<Vector3> m_moveRoutePosList = null;
	protected int m_routeListIndex = 0;
	protected eMoveType m_moveType = eMoveType.Random;

	public Route( )
	{
		this.m_moveType = eMoveType.OrderAsc;
		this.m_moveRoutePosList = new List<Vector3>();
		this.m_routeListIndex = 0;
	}
	public Route( eMoveType moveType )
	{
		this.m_moveType = moveType;
		this.m_moveRoutePosList = new List<Vector3>();
		this.m_routeListIndex = 0;
	}


	/// <summary>
	/// 次の座標のインデックスを計算
	/// </summary>
	public void CalcNextTargetIndex()
	{
		switch( this.m_moveType ) {
			case eMoveType.OrderAsc:
				this.m_routeListIndex = (this.m_routeListIndex + 1) % this.m_moveRoutePosList.Count;
				break;
			case eMoveType.OrderDesc:
				this.m_routeListIndex = (this.m_routeListIndex - 1);
				if( this.m_routeListIndex < 0 ) {
					this.m_routeListIndex = (this.m_moveRoutePosList.Count - 1);
				}
				break;
			case eMoveType.Random:
				this.m_routeListIndex = Random.Range( 0 , this.m_moveRoutePosList.Count );
				break;
		}
	}

	/// <summary>
	/// 指定した位置から一番近いルートのインデックスを計算
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	public bool CalcNearRoutePos( Vector3 pos )
	{
		return MyMath.CalcNearPos( ref this.m_routeListIndex , pos , this.m_moveRoutePosList );
	}

	public int GetRouteCount()
	{
		if( this.m_moveRoutePosList == null ) {
			return 0;
		}
		return this.m_moveRoutePosList.Count;
	}

	public Vector3 GetNowRoutePos()
	{
		return this.m_moveRoutePosList[this.m_routeListIndex];
	}

	public void AddRoutePos( Vector3 pos )
	{
		this.m_moveRoutePosList.Add( pos );
	}

	public void SetMoveType( eMoveType type )
	{
		this.m_moveType = type;
	}

}
