using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandRay : MonoBehaviour {
    Ray m_ray;
    Ray m_mouseRay;

    GameObject m_debugPoint;
	// Use this for initialization
	void Start () {
        //        m_ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //        Debug.DrawRay(m_ray.origin, m_ray.direction, Color.green, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        m_ray = new Ray(transform.position, transform.forward);
        m_mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(m_mouseRay.origin, m_mouseRay.direction, Color.green, 3.0f);
        LayerMask mask = 0;

        // Rayが衝突したコライダーの情報を得る.
        RaycastHit hit;
        // Rayが衝突したかどうか.
        if (Physics.Raycast(m_mouseRay, out hit, 100.0f, mask))
        {
            Debug.Log("hit");
            // Examples
            // 衝突したオブジェクトの色を赤に変える.
            hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            // 衝突したオブジェクトを消す.
            Destroy(hit.collider.gameObject);
            // Rayの衝突地点に、このスクリプトがアタッチされているオブジェクトを移動させる.
            this.transform.position = hit.point;
            // Rayの原点から衝突地点までの距離を得る.
            float dis = hit.distance;
            // 衝突したオブジェクトのコライダーを非アクティブにする.
            hit.collider.enabled = false;
        }


        // Rayが衝突した全てのコライダーの情報を得る。＊順序は保証されない.
        if (Input.GetMouseButton((int)InputManager.MouseButton.Left))
        {

            RaycastHit[] hits = Physics.RaycastAll(m_mouseRay, Mathf.Infinity);
            int min = 0;
            float minMagnitude = 10000.0f;
            int count = 0;
            foreach (var obj in hits)
            {
                float magnitude = (obj.point - Camera.main.transform.position).sqrMagnitude;
                if (minMagnitude > magnitude)
                {
                    minMagnitude = magnitude;
                    min = count;
                }
                ++count;
            }
            if (hits.Length > 0)
            {
                if (m_debugPoint == null)
                {
                    m_debugPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    m_debugPoint.GetComponent<SphereCollider>().enabled = false;
                    m_debugPoint.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                m_debugPoint.transform.position = hits[min].point;
//                Debug.LogFormat(hits[min].transform.gameObject, "HitPos x={0},y={1},z={2}", hits[min].point.x, hits[min].point.y, hits[min].point.z);
            }
        }
    }
}
