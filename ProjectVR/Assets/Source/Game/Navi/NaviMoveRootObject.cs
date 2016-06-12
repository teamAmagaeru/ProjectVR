using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NaviMoveRootObject : NaviMoveObject
{
	protected enum eMoveType {
		OrderAsc,	//順番
		OrderDesc,	//逆順
		Random		//ランダム
	};

	protected List<Vector3> m_moveRootPosList = null;
	protected eMoveType m_moveType = eMoveType.Random;
	protected int m_rootListIndex = 0;
	new void Awake()
	{
		base.Awake();

		if( m_moveRootPosList == null ) {
			m_moveRootPosList = new List<Vector3>();
			m_moveRootPosList.Add(new Vector3( 4f , transform.position.y , 2f ));
			m_moveRootPosList.Add(new Vector3( -4f , transform.position.y , 3f ));
			m_moveRootPosList.Add(new Vector3( 3f , transform.position.y , -3f ));
			m_moveRootPosList.Add(new Vector3( -2f , transform.position.y , -1f ) );
			SetDestination( m_moveRootPosList[0] );
		}
	}
	// Update is called once per frame
	void Update () {
		//
		if( IsStandOnTargetPos( m_moveRootPosList[m_rootListIndex] ) ) {
			ChangeToNextTarget();
		}


	}

	/// <summary>
	/// 次の目的地を設定
	/// </summary>
	public void ChangeToNextTarget()
	{
		if( m_moveRootPosList== null || m_moveRootPosList.Count == 0 ) {
			return;
		}
		//次の座標のインデックスを計算
		CalcNextTargetIndex();
		//次の座標をナビゲーションに設定
		SetDestination( m_moveRootPosList[ m_rootListIndex ] );
	}


	/// <summary>
	/// 次の座標のインデックスを計算
	/// </summary>
	public void	CalcNextTargetIndex()
	{
		switch( m_moveType ) {
			case eMoveType.OrderAsc:
				m_rootListIndex = (m_rootListIndex + 1) % m_moveRootPosList.Count;
				break;
			case eMoveType.OrderDesc:
				m_rootListIndex = (m_rootListIndex - 1);
				if(m_rootListIndex < 0) {
					m_rootListIndex = (m_moveRootPosList.Count-1);
				}
				break;
			case eMoveType.Random:
				m_rootListIndex = Random.Range( 0 , m_moveRootPosList.Count );
				break;
		}
	}

	public void AddRootPos( Vector3 pos )
	{
		m_moveRootPosList.Add( pos );
	}

}
