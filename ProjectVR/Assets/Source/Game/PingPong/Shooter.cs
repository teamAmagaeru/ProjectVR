using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

	const int BALL_LIMIT = 1;

	private List<Ball> m_ball_list = new List<Ball>();
	private int m_ball_index = 0;
	private InputManager.eDeviceType m_device_type;

	public void Init( InputManager.eDeviceType device_type)
	{
		m_device_type = device_type;
		transform.parent = InputManager.GetTransform( m_device_type );
		transform.localPosition = Vector3.zero;

	}

	// Update is called once per frame
	void Update () {
		if( InputManager.IsPullTrigger( m_device_type ) )
		{
			Ball.BallInitData ball_init_data = new Ball.BallInitData();
			Vector3 eulerAngles = InputManager.GetTransform( m_device_type ).rotation.eulerAngles;
			Vector3 force = transform.forward * 300;
			ball_init_data.force = force;
			ball_init_data.bound_num = -1;
			ball_init_data.time = -1;
			Shot( ball_init_data );
		}
		
	}

	void Shot( Ball.BallInitData ball_init_data )
	{
		/*
		if( m_ball_list.Count >= BALL_LIMIT )
		{
			return;
		}
		*/

		var ball_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Ball" ) );
		Vector3 add_pos = ball_init_data.force.normalized;
		ball_obj.transform.position = new Vector3( transform.position.x , transform.position.y , transform.position.z );
		ball_obj.transform.position += add_pos * 0.1f;
		ball_obj.transform.rotation = new Quaternion( transform.rotation.x , transform.rotation.y , transform.rotation.z , transform.rotation.w );
		var ball_data = ball_obj.GetComponent<Ball>();
		ball_data.Init(this , m_ball_index , ball_init_data );
		m_ball_list.Add( ball_data );

		m_ball_index++;
	}

	public void DeleteBall( Ball ball )
	{

		ball.OnDeleteFlg();
		m_ball_list.Remove( ball );
	}

	public void DeleteAllBall()
	{
		for( int i = 0 ; i < m_ball_list.Count ; i++ )
		{
			m_ball_list[i].OnDeleteFlg();
		}
		m_ball_list.Clear();
	}


}
