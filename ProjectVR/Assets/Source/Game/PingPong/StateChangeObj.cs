using UnityEngine;
using System.Collections;

public class StateChangeObj : MonoBehaviour {

	private bool m_is_delete = false;
	private GameStateManager m_game_state_manager = null;

	public void Init( GameStateManager game_state_manager )
	{
		m_game_state_manager = game_state_manager;
		transform.position = Define.Generate.StateChangeObjPos;

	}

	// Update is called once per frame
	void Update () {


		if( IsDelete() )
		{
			Destroy( this.gameObject );
		}
	}

	bool IsDelete()
	{
		if( m_is_delete )
		{
			return true;
		}

		return false;
	}

	void OnCollisionEnter( Collision col )
	{
		var ball = col.gameObject.GetComponent<Ball>();
		if( ball != null )
		{
			m_is_delete = true;

			m_game_state_manager.NextState();
			ball.OnDeleteFlg();

		}
	}

}
