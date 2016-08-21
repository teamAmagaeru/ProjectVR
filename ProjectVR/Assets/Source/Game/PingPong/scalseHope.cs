using UnityEngine;
using System.Collections;

public class scalseHope : MonoBehaviour {
    public float timer = 0;
    public ParticleSystem particleObj;
    private ParticleSystem[] childParticle;

    // Use this for initialization
    void Start () {
        particleObj = GetComponent<ParticleSystem>();
        particleObj.scalingMode = ParticleSystemScalingMode.Local;
        childParticle = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem  keyParticle in childParticle)
        {
            keyParticle.scalingMode = ParticleSystemScalingMode.Hierarchy;
        }
        //Debug.Log(particleObj.name);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if ((int)timer % 4 == 0) {
            timer++;
            float randScaleRate = Random.Range(0.5f, 3.0f);
            Vector3 tempScale = transform.localScale;
            tempScale.x = randScaleRate;
            tempScale.y = randScaleRate;
            tempScale.z = randScaleRate;
            particleObj.gameObject.transform.localScale = tempScale;
            //foreach (ParticleSystem keyParticle in childParticle)
            //{
            //    keyParticle.gameObject.transform.localScale = tempScale;
            //}
        }
	}
}
