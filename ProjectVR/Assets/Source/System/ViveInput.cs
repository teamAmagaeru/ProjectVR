using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViveInput : MonoBehaviour {



    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        var device = GetDevice();
        if (device == null)
        {
            return;
        }

        LogUpdate(device);

        if (m_vibrationTime != null)
        {
//            Debug.Log("time = " + m_vibrationTime.time);
            m_vibrationTime.Update();
            if (m_vibrationTime.IsEnd())
            {
                m_vibrationTime = null;
            }
//            device.TriggerHapticPulse(m_vibrationValue);
        }
        // タッチパッド押しっぱなしでチャージ.
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            m_chargeTime += Time.deltaTime;
            float rate = m_chargeTime / Define.Controller.ChargeTime;
            ushort value = (ushort)(Mathf.Lerp(Define.Controller.ChargeVibrationValueMin, Define.Controller.ChargeVibrationValueMax, rate));
//            device.TriggerHapticPulse(value);
        }
        else
        {
            m_chargeTime = 0.0f;
        }
    }

    /// <summary>
    /// トリガーを引いた瞬間か?.
    /// </summary>
    /// <returns>true:引いた瞬間 false:それ以外</returns>
    public bool IsPullTrigger()
    {
        return m_isPullTrigger;
    }
    /// <summary>
    /// タッチパッドを押しているか?.
    /// </summary>
    /// <returns>true:押している false:離している</returns>
    public bool IsPressTouchpad()
    {
        var device = GetDevice();
        if (device == null)
        {
            Debug.LogErrorFormat("not found device");
            return false;
        }
        return device.GetPress(SteamVR_Controller.ButtonMask.Touchpad);
    }
    /// <summary>
    /// コントローラーを振動させる.
    /// </summary>
    /// <param name="value">振動値.最大3999だが、100～2000辺りが有効範囲らしい</param>
    /// <param name="time">振動時間(sec)</param>
    public void TriggerHapticPulse(ushort value,float time)
    {
        m_vibrationValue = value;
        m_vibrationTime = new TimeCounter(time);
    }

    TimeCounter m_vibrationTime = null;
    float m_chargeTime = 0.0f;
    ushort m_vibrationValue = 0;

    bool m_isTriggerMax = false;
    bool m_isPullTrigger = false;


    /// <summary>
    /// デバイス取得.
    /// </summary>
    /// <returns>デバイス.無かったらnull</returns>
    SteamVR_Controller.Device GetDevice()
    {

        SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
        if (trackedObject == null || trackedObject.index == SteamVR_TrackedObject.EIndex.None)
        {
            return null;
        }
        return SteamVR_Controller.Input((int)trackedObject.index);
    }


    void LogUpdate(SteamVR_Controller.Device device) {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
#if ENABLE_LOG
            Debug.Log("トリガーを浅く引いた");
#endif
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
#if ENABLE_LOG
            Debug.Log("トリガーを深く引いた");
#endif
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
#if ENABLE_LOG
            Debug.Log("トリガーを離した");
#endif
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            Debug.Log("タッチパッドをクリックした");
#endif
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            //Debug.Log("タッチパッドをクリックしている");
#endif
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            Debug.Log("タッチパッドをクリックして離した");
#endif
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            Debug.Log("タッチパッドに触った");
#endif
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            Debug.Log("タッチパッドを離した");
#endif
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
#if ENABLE_LOG
            Debug.Log("メニューボタンをクリックした");
#endif
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
#if ENABLE_LOG
            Debug.Log("グリップボタンをクリックした");
#endif
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
#if ENABLE_LOG
            //Debug.Log("トリガーを浅く引いている");
#endif
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
#if ENABLE_LOG
            //Debug.Log("トリガーを深く引いている");
#endif
        }
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
#if ENABLE_LOG
            //Debug.Log("タッチパッドに触っている");
#endif
        }
        float value = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
#if ENABLE_LOG
        //Debug.LogFormat("トリガーの入力 = {0}",value);
#endif
        if (value >= 0.9f && !m_isTriggerMax)
        {
#if ENABLE_LOG
            Debug.Log("トリガーをカチっと引いた");
#endif
            m_isTriggerMax = true;
            m_isPullTrigger = true;
        }
        else
        {
            m_isPullTrigger = false;
        }
        if(value<0.9f && m_isTriggerMax)
        {
#if ENABLE_LOG
            Debug.Log("トリガーをカチっと引かなくなった");
#endif
            m_isTriggerMax = false;
        }

        Vector2 position = device.GetAxis();
#if ENABLE_LOG
        //Debug.Log("タッチパッドの位置 x: " + position.x + " y: " + position.y);
#endif

#if ENABLE_LOG
        //Debug.LogFormat("speed = {0}", device.velocity);
        //Debug.LogFormat("angle = {0}", device.angularVelocity);
#endif
    }   
}
