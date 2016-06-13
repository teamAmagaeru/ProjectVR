using UnityEngine;
using System.Collections;

public class NaviMoveObject : MonoBehaviour {
	/// <summary>
	/// ナビ用の移動オブジェクト
	/// http://docs.unity3d.com/jp/current/ScriptReference/NavMeshAgent.html
	/// </summary>
	protected NavMeshAgent m_agent;
	protected float m_targetRange = 0.5f;
	protected INaviState m_state = null;

	// Use this for initialization
	protected virtual void Awake() {
		this.m_agent = GetComponent<NavMeshAgent>();

		//test
		m_state = new NaviStateMoveToTarget( this , GameObject.FindObjectOfType<NaviMoveRouteObject>().gameObject );
	}

	// Update is called once per frame
	void Update ()
	{
		m_state.Action();

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="target_pos"></param>
	public void SetDestination( Vector3 target_pos)
	{
		this.m_agent.SetDestination( target_pos );
	}

	/// <summary>
	/// 目的地に着いたかチェック
	/// </summary>
	public bool IsStandOnTargetPos( Vector3 targetPos )
	{

		bool is_stand = false;
		if( this.m_agent.nextPosition == null ) {
			return true;
		}
		//m_agent.nextPosition は今の位置返してた
		is_stand = MyMath.CollisionBoxToPoint( transform.position , this.m_targetRange , targetPos );

		return is_stand;

	}
}
