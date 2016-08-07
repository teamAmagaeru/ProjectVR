using UnityEngine;
using System.Collections;

public class UINumBullet : MonoBehaviour {
    const int NUM_DIGIT = 2;    // 桁数.
    GameObject[] m_nums = new GameObject[NUM_DIGIT];

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetNumBullet(int num)
    {
        foreach (var n in m_nums)
        {
            if (n != null)
            {
                GameObject.Destroy(n);
            }
        }
        if (num <= 0)
        {
            return;
        }
        int t = 0;
        t = num / 10;
        m_nums[0] = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/UI/3DNumber/num_" + t));
        t = num % 10;
        m_nums[1] = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/UI/3DNumber/num_" + t));
        foreach (var n in m_nums)
        {
            if (n != null)
            {
                Utility.SetParent(transform, n.transform);
                n.transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
//        if (num >= 10)
        {
            Vector3 pos = Vector3.zero;
            pos.x = -0.04f;
            m_nums[0].transform.localPosition = pos;
            pos.x = 0.04f;
            m_nums[1].transform.localPosition = pos;
        }
    }
}
