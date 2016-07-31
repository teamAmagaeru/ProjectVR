using UnityEngine;
using System.Collections;

/// <summary>
/// 調整値のまとめ.
/// </summary>
static public class Define{

    //---------------------コントローラー系---------------------//
    static public class Controller
    {
        // ボールチャージ(もう使ってない).
        public const float  ChargeTime = 3.0f;               // 長押しの最大時間.
        public const ushort ChargeVibrationValueMin = 500;   // 長押しの最低振動.
        public const ushort ChargeVibrationValueMax = 2000;  // 長押しの最大振動.
        // ボールチャージ(レベルが変わったとき).
        public const ushort LevelChangeVibrationValue = 1000;   // レベル変更時の振動.
        public const float LevelChangeVibrationTime = 0.3f;     // レベル変更時の振動時間(sec).
        // ボール発射.
        public const ushort ShootVibrationValue = 1000;      // ボール発射時の振動強度.
        public const float  ShootVibrationTime = 0.1f;       // ボール発射時の振動時間(sec).
    }
    //---------------------シューター系---------------------//
    static public class Shooter {
        // チャージの段階ごとの設定.
        public class Charge {
            public float Time;  // 時間(sec).
            public float Speed; // スピード.
            public Charge(float time, float speed)
            {
                Time = time;
                Speed = speed;
            }
        }
        // チャージ.
        public static Charge[] ChargeSetting = new Charge[] {
            new Charge(0.0f, 300.0f),
            new Charge(0.5f, 600.0f),
            new Charge(1.0f, 900.0f),
            new Charge(1.5f, 1500.0f),
        };
    }
}
