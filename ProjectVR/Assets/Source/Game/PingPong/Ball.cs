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

		var rigid = GetComponent<Rigidbody>();
		rigid.AddForce( in_init_data.force );


		m_bound_cnt = 0;
		m_timer = 0;
		m_is_delete = false;
	}

	
	// Update is called once per frame
	void Update ()
	{

		if( IsDelete() )
		{
			if( m_parent != null )
			{
				m_parent.DeleteBall(this);
			}
			Destroy( this.gameObject );
		}
		m_timer++;
	}


	bool IsDelete()
	{
		if( m_is_delete )
		{
			return true;
		}

		if( m_init_data.bound_num > 0 && m_bound_cnt >= m_init_data.bound_num )
		{
			return true;
		}

		if( m_init_data.time > 0 && m_timer >= m_init_data.time )
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

	public int GetBoundNum()
	{
		return m_bound_cnt;
	}

	void OnCollisionEnter( Collision col )
	{
		//バウンド
		if( gameObject.layer == LayerMask.NameToLayer( "RouteBall" ) || gameObject.layer == LayerMask.NameToLayer( "CalcGoal" ) )
		{
			return;
		}
		if( col.gameObject.layer != LayerMask.NameToLayer( "Field" ) )
		{
			return;
		}

		m_bound_cnt++;

		//演出
		if( col.contacts.Length > 0 )
		{
			var bound_effect = Instantiate<GameObject>( Resources.Load<GameObject>( "Effect/bounds" ) );
			bound_effect.transform.position = col.contacts[0].point;

		}
	}

}
