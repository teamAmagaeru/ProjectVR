using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

	List<GoalTarget> m_goal = new List<GoalTarget>();

	void Init()
	{
		var goal_ary = FindObjectsOfType<GoalTarget>();
		m_goal.AddRange( goal_ary );
	}

	// Update is called once per frame
	void Update() {

	}


	bool IsClear()
	{
		int clear_goal_num = 0;
		for( int i = 0 ; i < m_goal.Count ; i++ )
		{
			if( ! m_goal[i].IsClear() )
			{
				return false;
			}
			clear_goal_num++;
		}

		if( clear_goal_num >= m_goal.Count )
		{
			return true;
		}

		return false;
	}


}
