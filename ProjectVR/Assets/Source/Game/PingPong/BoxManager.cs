using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class BoxManager : MonoBehaviour {

    private float timer = 1;
    private GameObject[] boxs;
    private List<GameObject> instanceBox = new List<GameObject>();

    public GameObject boxRoot = null;
    public GameObject boxPut = null;
    public GameObject mySphere = null;
    public GameObject destroySphere = null;
    private GameObject destroySpherePre = null;
    private GameObject spherePre = null;
    //private Rigidbody sphereRb;
    const float putTimeMin = 0.8f;
    const float putTimeMax = 1.0f;
    private float putTimer;
    //障害物の一辺を定義(最長の辺、四面体とする）
    const float boxAreaLength = 0.9f;
    private float boxScale;

    private float boxSize;
    int[] putNum = new int[] { 13, 13, 13 };


    enum EState {
        NONE,
        UPDATE,
    }

    EState m_state = EState.NONE;




    // Use this for initialization
    public void Init(GameObject sphere)
    {
        spherePre = sphere;
        putTimer = UnityEngine.Random.Range(putTimeMin, putTimeMax);
        m_state = EState.NONE;


        GameObject prefab = (GameObject)Resources.Load("prefap/box_pre");
        //障害物の一辺を定義(最長の辺、四面体とする）
        boxScale = prefab.transform.localScale.x;
        //最長の辺の辺に対して回転体を作ってコリジョンが重ならないように
        boxSize = boxScale * (float)(System.Math.Sqrt(System.Math.Pow(boxAreaLength, 2) * 2));
        Debug.Log(prefab.name);
        Vector3 placePosition = new Vector3(-putNum[0] / 2 * boxSize, -putNum[1] / 2 * boxSize, -putNum[2] / 2 * boxSize);
        Vector3 tempPostion = placePosition;
        for (int x = 0; x < putNum[0]; x++)
        {
            for (int y = 0; y < putNum[1]; y++)
            {
                for (int z = 0; z < putNum[2]; z++)
                {
                    tempPostion.x = placePosition.x + boxSize * x;
                    tempPostion.y = placePosition.y + boxSize * y;
                    tempPostion.z = placePosition.z + boxSize * z;
                    instanceBox.Add(Instantiate(prefab, tempPostion, Quaternion.identity) as GameObject);
                }        
            }
            tempPostion = placePosition;
        }

        int itemNum = 0;
        float initRote = 140.0f;
        foreach (GameObject keyObj in instanceBox)
        {
            keyObj.transform.parent = boxRoot.transform;
            keyObj.name = keyObj.name + itemNum++;
            keyObj.transform.localRotation = Quaternion.Euler(UnityEngine.Random.Range(0, initRote), UnityEngine.Random.Range(0, initRote), UnityEngine.Random.Range(0, initRote));
        }


    }

    // Update is called once per frame
    public void Update()
    {
        if (m_state != EState.UPDATE)
        {
            return;
        }
        timer += Time.deltaTime;
        putTimer -= Time.deltaTime;
        if ((int)timer % 4 == 0 && spherePre == null && destroySpherePre == null)
        {
            timer=1;
            destroySpherePre = Instantiate(destroySphere, mySphere.transform.localPosition, Quaternion.identity) as GameObject;
            Destroy(boxRoot);
            //spherePre = Instantiate(mySphere, mySphere.transform.localPosition, Quaternion.identity) as GameObject;
            //spherePre.GetComponent<SphereCollider>().isTrigger = true;
        }

        if (putTimer <= 0 && spherePre != null)
        {
            
            putTimer = UnityEngine.Random.Range(putTimeMin, putTimeMax);
            //Destroy(destroySpherePre);
            spherePre.GetComponent<showRigidbodyInfo>().SetDestroyActive();


            var child_obj_ary = boxRoot.GetComponentsInChildren<Collider>();
            foreach (var child_obj in child_obj_ary)
            {
                child_obj.isTrigger = false;
            }
        }
        
    }
            
}
