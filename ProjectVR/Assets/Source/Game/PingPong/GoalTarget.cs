using UnityEngine;
using System.Collections;

/// <summary>
/// ボールが当たったら当たった用の演出する
/// 複数存在する
/// </summary>
public class GoalTarget : MonoBehaviour {

	private bool m_is_clear = false;


	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter( Collision col )
	{
		var ball = col.gameObject.GetComponent<Ball>();
		if( ball != null )
		{
			m_is_clear = true;
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
}
