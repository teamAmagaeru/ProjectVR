using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

	const int BALL_LIMIT = 1;

	private List<Ball> m_ball_list;
	private int ball_index = 0;
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTrans( Vector3 pos , Quaternion rotate)
	{
		gameObject.transform.position = pos;
		gameObject.transform.rotation = rotate;
	}


	void Shot( Ball.BallInitData ball_init_data )
	{
		if( m_ball_list.Count >= BALL_LIMIT )
		{
			return;
		}

		var ball_obj = Instantiate<GameObject>( Resources.Load<GameObject>("") );
		var ball_data = ball_obj.GetComponent<Ball>();
		ball_data.Init(this , ball_index , ball_init_data );
		m_ball_list.Add( ball_data );

		ball_index++;
	}

	public void DeleteBall( Ball ball )
	{
		m_ball_list.Remove( ball );
	}


}
