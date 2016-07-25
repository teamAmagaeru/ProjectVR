using UnityEngine;
using System.Collections;

/// <summary>
/// 調整値のまとめ.
/// </summary>
static public class Define{

    //---------------------コントローラー系---------------------//
    static public class Controller
    {
        // ボールチャージ.
        public const float  ChargeTime = 3.0f;               // 長押しの最大時間.
        public const ushort ChargeVibrationValueMin = 500;   // 長押しの最低振動.
        public const ushort ChargeVibrationValueMax = 2000;  // 長押しの最大振動.
        // ボール発射.
        public const ushort ShootVibrationValue = 1000;      // ボール発射時の振動強度.
        public const float  ShootVibrationTime = 0.1f;       // ボール発射時の振動時間(sec).
    }
}
