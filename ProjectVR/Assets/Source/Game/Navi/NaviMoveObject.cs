using UnityEngine;
using System.Collections;

public class NaviMoveObject : MonoBehaviour {
	/// <summary>
	/// ナビ用の移動オブジェクト
	/// http://docs.unity3d.com/jp/current/ScriptReference/NavMeshAgent.html
	/// </summary>
	protected NavMeshAgent m_agent;
	protected float m_targetRange = 0.5f;

	// Use this for initialization
	protected void Awake() {
		m_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetDestination( Vector3 target_pos)
	{
		m_agent.SetDestination( target_pos );
	}

	/// <summary>
	/// 目的地に着いたかチェック
	/// </summary>
	public bool IsStandOnTargetPos( Vector3 targetPos )
	{
		bool is_stand = false;
		if( m_agent.nextPosition == null ) {
			return true;
		}
		//m_agent.nextPosition は今の位置返してた
		is_stand = MyMath.CollisionBoxToPoint( transform.position , m_targetRange , targetPos );

		return is_stand;

	}
}
