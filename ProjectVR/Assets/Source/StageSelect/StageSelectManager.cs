using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageSelectManager : MonoBehaviour {

    List<StageSelectObj> m_objects = new List<StageSelectObj>();
    const int m_stageNum = 3;
    // Use this for initialization
    void Start() {
        Vector3[] posTable = new Vector3[m_stageNum] {
            new Vector3(-0.5f,0.5f,0.0f),
            new Vector3( 0.0f,0.5f,0.0f),
            new Vector3( 0.5f,0.5f,0.0f)
        };
        for (int i = 0; i < m_stageNum; ++i)
        {
            StageSelectObj obj = SystemManager.Create<StageSelectObj>("Prefab/StageSelect/StageSelectObj");
            obj.ChangeText(i+1);
            m_objects.Add(obj);
            obj.gameObject.transform.localPosition = posTable[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
