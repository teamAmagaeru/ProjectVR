using UnityEngine;
using System.Collections;

public class AnimationObject : MonoBehaviour
{
	private Animator m_anim = null;
	// Use this for initialization
	void Awake ()
	{
		m_anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update ()
	{
	}

	public void Init( Animator anim )
	{
		m_anim = anim;
	}

	public void PlayAnim( string animName )
	{
		m_anim.Play( animName );
	}
	public void StopAnim()
	{
		m_anim.enabled = false;
	}
	public void StartAnim()
	{
		m_anim.enabled = true;
	}

}
