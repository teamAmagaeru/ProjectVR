using UnityEngine;
using System.Collections;

public class AnimationObject : MonoBehaviour {

	Animator m_anim = null;

	// Use this for initialization
	void Awake() {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Init( Animator anim )
	{
		m_anim = anim;
	}

	public void Stop()
	{
		m_anim.enabled = false;
	}

	public void Continue()
	{
		m_anim.enabled = true;
	}

	public void ChangeState( string state )
	{
		m_anim.Play( state );
	}


}
