using UnityEngine;
using System.Collections;

public class NaviStateMoveToTarget : NaviState
{
	protected GameObject m_target_obj;

	public NaviStateMoveToTarget( NaviMoveObject naviMoveObj , GameObject target_obj )
		: base( naviMoveObj )
	{
		this.m_target_obj = target_obj;

		this.m_naviMoveObj.SetDestination( this.m_target_obj.transform.position );
	}

	override public void Action()
	{
		this.m_naviMoveObj.SetDestination( this.m_target_obj.transform.position );
	}
}
