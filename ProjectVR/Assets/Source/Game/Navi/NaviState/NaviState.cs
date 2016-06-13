using UnityEngine;
using System.Collections;

public class NaviState : INaviState
{
	protected NaviMoveObject m_naviMoveObj = null;

	public NaviState( NaviMoveObject naviMoveObj )
	{
		this.m_naviMoveObj = naviMoveObj;
	}

	public virtual void Action()
	{
	}
}
