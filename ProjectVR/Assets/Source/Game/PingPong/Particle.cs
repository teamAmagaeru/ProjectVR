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
			return;
		}

		if( ! m_particle.IsAlive() )
		{
			Destroy( gameObject );
		}
	}

}
