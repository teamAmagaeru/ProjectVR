using UnityEngine;
using System.Collections;

public class AudioData : MonoBehaviour {

	private AudioSource m_audio_source = null;


	public void Play( AudioClip audio_clip , bool is_loop = false)
	{
		if( m_audio_source == null)
		{
			m_audio_source = GetComponent<AudioSource>();
		}
		m_audio_source.clip = audio_clip;
		m_audio_source.Play();
		m_audio_source.loop = is_loop;
	}


	// Update is called once per frame
	void Update () {

		if( m_audio_source != null )
		{
			if( ! m_audio_source.isPlaying )
			{
				Destroy(this.gameObject);
			}
		}
	}
}
