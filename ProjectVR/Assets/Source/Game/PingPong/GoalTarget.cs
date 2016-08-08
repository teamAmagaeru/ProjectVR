using UnityEngine;
using System.Collections;

/// <summary>
/// ボールが当たったら当たった用の演出する
/// 複数存在する
/// </summary>
public class GoalTarget : MonoBehaviour
{

	private bool m_is_clear = false;
	private bool m_is_delete = false;

	private GameStateManager m_game_state_manager = null;

	public void Init( GameStateManager game_state_manager )
	{
		m_game_state_manager = game_state_manager;
	}


	// Update is called once per frame
	void Update()
	{

		if( IsDelete() )
		{
			Destroy( this.gameObject );
		}
	}

	void OnCollisionEnter( Collision col )
	{
		var ball = col.gameObject.GetComponent<Ball>();
		if( ball != null )
		{
			m_is_clear = true;

			m_game_state_manager.Goal( ball.GetBoundNum() , transform.position );

			var se_clip = Resources.Load<AudioClip>( "Sounds/goalSe" );
			var se_data = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/AudioData" ) );
			se_data.GetComponent<AudioData>().Play( se_clip );

			DeleteBall( ball );
		}
	}

	public bool IsClear()
	{
		return m_is_clear;
	}

	private void DeleteBall( Ball ball )
	{
		ball.OnDeleteFlg();
	}

	bool IsDelete()
	{
		if( m_is_delete )
		{
			return true;
		}

		return false;
	}
	public void OnDeleteFlg()
	{
		m_is_delete = true;
	}
}