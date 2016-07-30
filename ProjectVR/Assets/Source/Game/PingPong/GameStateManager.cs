using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

	List<GoalTarget> m_goal = new List<GoalTarget>();
	List<Shooter> m_shooter = new List<Shooter>();

	void Awake()
	{
		InitShooter();
		GenerateMap();
	}

	void InitShooter()
	{
		if( m_shooter.Count == 0 )
		{
			{
				GameObject shooter_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Shooter" ) );
				var shooter = shooter_obj.GetComponent<Shooter>();
				shooter.Init( InputManager.eDeviceType.Left );
				m_shooter.Add( shooter );
			}
			{
				GameObject shooter_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Shooter" ) );
				var shooter = shooter_obj.GetComponent<Shooter>();
				shooter.Init( InputManager.eDeviceType.Right );
				m_shooter.Add( shooter );
			}
		}

	}


	void GenerateMap()
	{
		//ゴールの座標計算
		GameObject goal_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Goal" ) );

		Vector3 pos = new Vector3();
		pos.x = Random.Range( 0f , 3f );
		pos.y = Random.Range( 0f , 3f );
		pos.z = Random.Range( 0f , 3f );

		goal_obj.transform.position = pos;
		m_goal.Add( goal_obj.GetComponent<GoalTarget>() );

	}



	// Update is called once per frame
	void Update() {
		if( IsClear() )
		{
			ResetMap();
			GenerateMap();
		}
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


	void ResetMap()
	{
		for( int i = 0 ; i < m_shooter.Count ; i++ )
		{
			m_shooter[i].DeleteAllBall();
		}

		for( int i = 0 ; i < m_goal.Count ; i++ )
		{
			m_goal[i].OnDeleteFlg();
		}
	}


}
