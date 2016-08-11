using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	ParticleSystem m_particle = null;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update() {
		if( m_particle == null )
		{
			m_particle = GetComponent<ParticleSystem>();
			ParticleScaler( gameObject );
			for( int i = 0 ; i < transform.childCount ; i++ )
			{
				ParticleScaler( transform.GetChild(i).gameObject );
			}
			
			return;
		}
		ParticleScaler( gameObject );
		for( int i = 0 ; i < transform.childCount ; i++ )
		{
			ParticleScaler( transform.GetChild( i ).gameObject );
		}

		if( ! m_particle.IsAlive() )
		{
			Destroy( gameObject );
		}
	}

	public void ParticleScaler( GameObject obj)
	{
		//Vector3 center =  Camera.current.worldToCameraMatrix.MultiplyPoint3x4(transform.position);

		//GetComponent<ParticleRenderer>().material.SetVector("_Center", center);
		if( obj.GetComponent<ParticleSystem>() == null )
		{
			return;
		}
		if( Camera.current == null )
		{
			return;
		}
		obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetVector( "_Center" , transform.position );
		obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetVector( "_Scaling" , new Vector3(0.2f,0.2f,0.2f) );
		obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetMatrix( "_Camera" , Camera.current.worldToCameraMatrix );
		obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetMatrix( "_CameraInv" , Camera.current.worldToCameraMatrix.inverse );
	}
}
