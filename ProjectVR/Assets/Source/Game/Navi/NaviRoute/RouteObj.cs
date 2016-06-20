using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RouteObj : MonoBehaviour {
	protected RouteGroup m_group;	//自分のいるグループ


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGroup( RouteGroup group )
	{
		this.m_group = group;
	}

	public RouteGroup GetGroup()
	{
		return this.m_group ;
	}

}
