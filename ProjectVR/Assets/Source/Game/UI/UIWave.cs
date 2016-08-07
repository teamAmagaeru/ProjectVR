using UnityEngine;
using System.Collections;

/// <summary>
/// wave管理.
/// </summary>
public class UIWave : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AppearWave(int wave)
    {
        TextMesh[] textMesh = transform.GetComponentsInChildren<TextMesh>();
        if (textMesh != null && textMesh.Length>0 && textMesh[0] != null)
        {
            textMesh[0].text = "wave " + wave;
        }
    }
}
