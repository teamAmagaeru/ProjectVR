using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

	const int BALL_LIMIT = 1;

	private List<Ball> m_ball_list = new List<Ball>();
	private int m_ball_index = 0;
	private InputManager.eDeviceType m_device_type;

    private TimeCounter m_chargeTime = null;
    private int m_chargeLevel = 0;

	private ResultData m_result_data;

	private int m_timer = 0;


	public void Init( InputManager.eDeviceType device_type , ResultData result_data )
	{
		m_device_type = device_type;
		m_result_data = result_data;
		transform.parent = InputManager.GetTransform( m_device_type );
		transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

	}

	// Update is called once per frame
	void Update () {

		if( InputManager.IsPullTrigger( m_device_type ) )
		{
			Ball.BallInitData ball_init_data = new Ball.BallInitData();
			Vector3 eulerAngles = InputManager.GetTransform( m_device_type ).rotation.eulerAngles;
			Vector3 force = transform.forward * Define.Shooter.ChargeSetting[m_chargeLevel].Speed;
			ball_init_data.force = force;
			ball_init_data.bound_num = -1;
			ball_init_data.time = Define.Shooter.ChargeSetting[m_chargeLevel].BallAliveFrame;
			Shot( ball_init_data );
		}

		ShotRouteBall();

		// チャージ処理.
		if (InputManager.IsPressTouchpad(m_device_type))
        {
            if (m_chargeTime == null)
            {
                float max = Define.Shooter.ChargeSetting[Define.Shooter.ChargeSetting.Length - 1].Time;
                m_chargeTime = new TimeCounter(TimeCounter.eType.CountUp, max);
            }else
            {
                int level = 0;
                m_chargeTime.Update();
                for(int i=0;i<Define.Shooter.ChargeSetting.Length;++i)
                {
                    if (m_chargeTime.time >= Define.Shooter.ChargeSetting[i].Time)
                    {
                        level = i;
                    }
                }
                if(m_chargeLevel != level)
                {
                    Debug.LogFormat("チャージレベル{0}にアップ!", level);
                    m_chargeLevel = level;
                    InputManager.TriggerHapticPulse(m_device_type, Define.Controller.LevelChangeVibrationValue, Define.Controller.LevelChangeVibrationTime);
                }
            }

        }else
        {
            // チャージを減らす処理めんどいし、離したらリセットで良くない...?.
            m_chargeLevel = 0;
            m_chargeTime = null;
        }

		m_timer++;
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

		m_result_data.AddBallCnt();


		var se_clip = Resources.Load<AudioClip>( "Sounds/shootSe" );
		var se_data = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/AudioData" ) );
		se_data.GetComponent<AudioData>().Play( se_clip );

	}

	void ShotRouteBall()
	{
		if( m_timer % Define.Shooter.OrbitPLan.ShootFrame != 0)
		{
			return;
		}

		Ball.BallInitData ball_init_data = new Ball.BallInitData();
        if (InputManager.ExistDevice(m_device_type) == false)
        {
            return;
        }
        Vector3 eulerAngles = InputManager.GetTransform( m_device_type ).rotation.eulerAngles;
		Vector3 force = transform.forward * Define.Shooter.ChargeSetting[m_chargeLevel].Speed;
		ball_init_data.force = force;
		ball_init_data.bound_num = -1;
		ball_init_data.time = Define.Shooter.OrbitPLan.BallDeleteFrame;


		var ball_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/BallFake" ) );
		ball_obj.layer = LayerMask.NameToLayer( "RouteBall" );

		Vector3 add_pos = ball_init_data.force.normalized;
		ball_obj.transform.position = new Vector3( transform.position.x , transform.position.y , transform.position.z );
		ball_obj.transform.position += add_pos * 0.1f;
		ball_obj.transform.rotation = new Quaternion( transform.rotation.x , transform.rotation.y , transform.rotation.z , transform.rotation.w );
		var ball_data = ball_obj.GetComponent<Ball>();
		ball_data.Init( this , m_ball_index , ball_init_data );
		m_ball_list.Add( ball_data );
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
