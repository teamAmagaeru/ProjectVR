using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public class BallInitData
	{
		public Vector3 force;
		public int bound_num;
		public int time;

	}

	int m_index;
	BallInitData m_init_data = new BallInitData();
	int m_bound_cnt;
	int m_timer;

	Shooter m_parent;
	bool m_is_delete;


	public void Init( Shooter in_pingpong , int in_index , BallInitData in_init_data )
	{
		m_parent = in_pingpong;
		m_index = in_index;
		m_init_data = in_init_data;

		GetComponent<Rigidbody>().AddForce( in_init_data.force );


		m_bound_cnt = 0;
		m_timer = 0;
		m_is_delete = false;
	}

	
	// Update is called once per frame
	void Update ()
	{

		if( IsDelete() )
		{
			m_parent.DeleteBall(this);
			Destroy( this.gameObject );
		}
	}


	bool IsDelete()
	{
		if( m_is_delete )
		{
			return true;
		}

		if( m_bound_cnt >= m_init_data.bound_num )
		{
			return true;
		}

		if( m_timer >= m_init_data.time )
		{
			return true;
		}

		return false;
	}

	public void OnDeleteFlg( )
	{
		m_is_delete = true;
	}

	public int GetIndex()
	{
		return m_index;
	}

}
