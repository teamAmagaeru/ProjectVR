using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

	enum eGameState{
		Before,
		Play,
		End
	}

	private int m_clear_cnt = 0;

	List<GoalTarget> m_goal = new List<GoalTarget>();
	List<Shooter> m_shooter = new List<Shooter>();

	private eGameState m_state = eGameState.Before;
	private ResultData m_result_data = new ResultData();

	//次のウェーブで開放するオブジェクトのID
	private int m_next_release_id = 0;
	//障害物
	List<GameObject> m_obj_list = new List<GameObject>();
	//ゴールの位置
	List<Vector3> m_goal_pos_list = new List<Vector3>();
	const int WAVE_MAX = 15;

	bool m_next_coroutine_flg = false;
	bool m_generate_goal_coroutine_flg = false;

	AudioData m_bgm_data = null;

	void Awake()
	{
		m_state = eGameState.Before;
		InitShooter();

		m_bgm_data = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/AudioData" ) ).GetComponent<AudioData>();
		var clip = Resources.Load<AudioClip>( "Sounds/titleBgm" );
		m_bgm_data.GetComponent<AudioData>().Play( clip ,true);
	}

	void Init()
	{
		m_result_data.Init(this);
		m_clear_cnt = 0;
		m_next_release_id = 0;
		GenerateMap();
		StartCoroutine( NextWave() );

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
		GenerateObjectByPrefab();
		StartCoroutine( GenerateGoalPos() );

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
			m_state = eGameState.Play;
			Init();
			UIManager.EnableNumBullet(ResultData.BALL_MAX);
			UIManager.EnableScore(0);

			var clip = Resources.Load<AudioClip>( "Sounds/playBgm" );
			m_bgm_data.GetComponent<AudioData>().Play( clip , true );
		}
	}

	void StatePlay()
	{
		if( IsClear() )
		{
			//waveクリア
			m_clear_cnt++;
			UIManager.AppearWave( m_clear_cnt );

			var se_clip = Resources.Load<AudioClip>( "Sounds/lvelUpSe" );
			var se_data = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/AudioData" ) );
			se_data.GetComponent<AudioData>().Play( se_clip );


			for( int i = 0 ; i < m_goal.Count ; i++ )
			{
				m_goal[i].OnDeleteFlg();
			}
			m_goal.Clear();
			if( m_clear_cnt < WAVE_MAX-1 )
			{
				StartCoroutine( NextWave() );
			}
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
		UIManager.DisableNumBullet();
		m_state = eGameState.Before;
	}

	/// <summary>
	/// ウェーブのクリア判定
	/// </summary>
	/// <returns></returns>
	bool IsClear()
	{
		if( m_goal.Count == 0 )
		{
			return false;
		}

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
		this.m_goal.Clear();
		this.m_goal_pos_list.Clear();
	}

	/// <summary>
	/// ゲームが始まっているかチェック
	/// </summary>
	/// <returns></returns>
	public bool IsStatePlay()
	{
		return m_state == eGameState.Play;
	}


	/// <summary>
	/// 
	/// </summary>
	public IEnumerator NextWave()
	{
		if( m_next_coroutine_flg )
		{
			yield break;
		}
		m_next_coroutine_flg = true;
		//障害物かゴールの数が足りないとき待機
		while( m_obj_list.Count <= m_next_release_id || m_goal_pos_list.Count <= m_next_release_id )
		{
			if( !IsStatePlay() )
			{
				m_next_coroutine_flg = false;
				yield break;
			}
			yield return 0;
		}

		m_obj_list[m_next_release_id].layer = LayerMask.NameToLayer( "Field" );
        Utility.SetRendererEnable(m_obj_list[m_next_release_id], true);


		GameObject goal_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Goal" ) );
		goal_obj.transform.position = this.m_goal_pos_list[m_next_release_id];
		GoalTarget goal = goal_obj.GetComponent<GoalTarget>();
		goal.Init( this );
		m_goal.Add( goal );

		m_next_release_id++;

		m_next_coroutine_flg = false;
		yield return 0;
	}

	public void Goal( int bound_num , Vector3 position)
	{

		m_result_data.AddScoreByBoundNum( bound_num , position );

	}

	/// <summary>
	/// ぷれはぶから障害物をランダムに配置
	/// 不可視でゴール生成用レイヤーに非アクティブ状態で配置
	/// </summary>
	void GenerateObjectByPrefab()
	{
		if( m_obj_list.Count > 0 )
		{
			Destroy( m_obj_list[0].transform.parent.gameObject );
			m_obj_list.Clear();
		}

		GameObject all_obj_base = Resources.Load<GameObject>( "Prefab/PingPong/AllObjects" );
		GameObject all_obj = GameObject.Instantiate<GameObject>( all_obj_base );

		List<int> child_id_list = new List<int>();

		for( int i = 0 ; i < all_obj.transform.childCount ; i++ )
		{
			child_id_list.Add( i );
		}

		//順番をランダムにする
		for( int i = 0 ; i < all_obj.transform.childCount ; i++ )
		{
			GameObject obj = all_obj.transform.GetChild( i ).gameObject;
			m_obj_list.Add( obj );
		}
		/*
		while( child_id_list.Count > 0 )
		{
			int child_id_key = Random.Range( 0 , child_id_list.Count );
			int child_id = child_id_list[child_id_key];
			GameObject obj = all_obj.transform.GetChild( child_id ).gameObject;

			obj.layer = LayerMask.NameToLayer( "CalcGoal" );
            Utility.SetRendererEnable(obj, false);
			obj.SetActive(false);
			m_obj_list.Add( obj );

			child_id_list.RemoveAt( child_id_key );
		}
		*/
	}

	/// <summary>
	/// ゴール位置が生成されるときに障害物をアクティブにする
	/// </summary>
	/// <returns></returns>
	public IEnumerator GenerateGoalPos()
	{
		if( m_generate_goal_coroutine_flg )
		{
			yield break;
		}
		m_generate_goal_coroutine_flg = true;

		while( this.m_goal_pos_list.Count < WAVE_MAX )
		{
			//ゴールと同じIDの障害物をアクティブにする
			m_obj_list[this.m_goal_pos_list.Count].SetActive( true );
			//ゴール生成用の球を飛ばす


			var ball_obj = Instantiate<GameObject>( Resources.Load<GameObject>( "Prefab/PingPong/Ball" ) );
			var ball_data = ball_obj.GetComponent<Ball>();
			ball_obj.layer = LayerMask.NameToLayer( "CalcGoal" );

			Ball.BallInitData ball_init_data = new Ball.BallInitData();
			//球飛ばす位置
			ball_obj.transform.position = new Vector3(
				Define.Generate.Goal.ShootPos.x ,
				Define.Generate.Goal.ShootPos.y ,
				Define.Generate.Goal.ShootPos.z
			);
			//球飛ばす強さ
			int force_type = Random.Range( 0 , Define.Shooter.ChargeSetting.Length );
			//球飛ばす方向
			Vector3 angle = new Vector3(
				Random.Range( Define.Generate.Goal.ShootAngleMin.x , Define.Generate.Goal.ShootAngleMax.x ) ,
				Random.Range( Define.Generate.Goal.ShootAngleMin.y , Define.Generate.Goal.ShootAngleMax.y ) ,
				Random.Range( Define.Generate.Goal.ShootAngleMin.z , Define.Generate.Goal.ShootAngleMax.z ) 
			);
			Vector3 force = angle.normalized * Define.Shooter.ChargeSetting[force_type].Speed;
			ball_init_data.force = force;
			ball_init_data.bound_num = -1;
			ball_init_data.time = -1;
			ball_data.Init( null , -1 , ball_init_data );


			//球飛ばしてnフレーム経過したら、ゴール位置確定
			//球が存在するフレーム数
			int frame_end = Random.Range( Define.Generate.Goal.PutGoalPosFrameMin , Define.Generate.Goal.PutGoalPosFrameMax );
			int now_frame = 0;
			while( now_frame < frame_end )
			{
				now_frame++;

				if( ! IsStatePlay() )
				{
					m_generate_goal_coroutine_flg = false;
					yield break;
				}

				yield return 0;
			}

			//位置決定
			m_goal_pos_list.Add( ball_obj.transform.position );
			ball_data.OnDeleteFlg();

		}

		m_generate_goal_coroutine_flg = false;

		yield return 0;
	}

}
