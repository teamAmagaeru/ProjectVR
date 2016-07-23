using UnityEngine;
using System.Collections;
/// <summary>
/// ボールが当たるとボールを消す
/// </summary>
public class Blocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision col )
	{
		var ball = col.gameObject.GetComponent<Ball>();
		if( ball != null )
		{
			DeleteBall( ball );
		}
	}

	private void DeleteBall( Ball ball )
	{
		ball.OnDeleteFlg();
	}

}
