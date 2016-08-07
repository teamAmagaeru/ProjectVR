using UnityEngine;
using System.Collections;

public class ResultData {

	const int BALL_MAX = 20;
	int m_ball_cnt = 0;
	GameStateManager m_state_manager;

	public void Init( GameStateManager state_manager )
	{
		m_ball_cnt = 0;
		m_state_manager = state_manager;
	}

	/// <summary>
	/// ゲーム終了判定
	/// </summary>
	/// <returns></returns>
	public bool IsFinish()
	{
		if( ! m_state_manager.IsStatePlay() )
		{
			return false;
		}
		return m_ball_cnt >= BALL_MAX;
	}

	/// <summary>
	/// ゲーム中に飛ばしたボールの数カウント
	/// </summary>
	public void AddBallCnt()
	{
		if( ! m_state_manager.IsStatePlay() )
		{
			return;
		}
		m_ball_cnt++;
		UIManager.SetNumBullet( BALL_MAX - m_ball_cnt );
	}

}
