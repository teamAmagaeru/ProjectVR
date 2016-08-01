using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

	enum eGameState{
		Before,
		Play,
		End
	}


	static public int m_ball_cnt = 0;
	private int m_clear_cnt = 0;

	List<GoalTarget> m_goal = new List<GoalTarget>();
	List<Shooter> m_shooter = new List<Shooter>();

	private eGameState m_state = eGameState.Before;
	private ResultData m_result_data = new ResultData();


	void Awake()
	{
		m_state = eGameState.Before;
		Init();
	}

	void Init()
	{
		m_result_data.Init(this);
		m_ball_cnt = 0;
		m_clear_cnt = 0;
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
				shooter.Init( InputManager.eDeviceType.Left , m_result_data);
				m_shooter.Add( shooter );
			}
			{
				GameObject shooter_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Shooter" ) );
				var shooter = shooter_obj.GetComponent<Shooter>();
				shooter.Init( InputManager.eDeviceType.Right , m_result_data );
				m_shooter.Add( shooter );
			}
		}

	}


	void GenerateMap()
	{

		GenerateGoal();


	}

	/// <summary>
	/// 次のゴールを配置するだけ
	/// </summary>
	void GenerateGoal()
	{
		//ゴールの座標計算
		GameObject goal_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Goal" ) );

		Vector3 pos = new Vector3();
		pos.x = Random.Range( -5.0f , 5.0f );
		pos.y = Random.Range( 0.5f , 1.5f );
		pos.z = Random.Range( 1.0f , 3.0f );

		goal_obj.transform.position = pos;
		m_goal.Add( goal_obj.GetComponent<GoalTarget>() );
	}

	/// <summary>
	/// 全ウェーブ分計算をする
	/// 計算用の透明オブジェクトで全データができるまで計算
	/// </summary>
	void CalcGoalPos()
	{
	}



	// Update is called once per frame
	void Update() {
		switch( m_state )
		{
			case eGameState.Before:
				StateBefore();
				break;
			case eGameState.Play:
				StatePlay();
				break;
			case eGameState.End:
				StateEnd();
				break;
		}


	}


	void StateBefore()
	{
		//ゲームスタートしてから
		{
			ResetMap();
			Init();
			m_state = eGameState.Play;
		}
	}

	void StatePlay()
	{
		if( IsClear() )
		{
			//waveクリア
			m_clear_cnt++;
			GenerateMap();
		}

		if( IsGameFinish() )
		{
			//ゲーム終了
			ResetMap();

			m_state = eGameState.End;
		}
	}
	void StateEnd()
	{
		m_state = eGameState.Before;
	}

	/// <summary>
	/// ウェーブのクリア判定
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// ゲームの終了判定
	/// </summary>
	/// <returns></returns>
	bool IsGameFinish()
	{
		return m_result_data.IsFinish();
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

	public bool IsStatePlay()
	{
		return m_state == eGameState.Play;
	}

}
