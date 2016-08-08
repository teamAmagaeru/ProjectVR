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
            public int BallAliveFrame; // 球の生存時間.
            public Charge(float time , float speed , int ballAliveFrame )
            {
                Time = time;
                Speed = speed;
				BallAliveFrame = ballAliveFrame;

			}
        }
        // チャージ.
        public static readonly Charge[] ChargeSetting = new Charge[] {
            new Charge(0.0f, 300.0f , 180),
            new Charge(0.5f, 600.0f , 180),
            new Charge(1.0f, 900.0f , 180),
            new Charge(1.5f, 1500.0f , 180),
        };

		//予測用の球関係のデータ
		public static class OrbitPLan
		{
			//球を飛ばす感覚
			public const int ShootFrame = 10;
			//球が消えるフレーム
			public const int BallDeleteFrame = 60;
		}

    }

	static public class Generate
	{
		static public class Goal
		{
			//ゴール生成用の球を発射する位置
			public static readonly Vector3 ShootPos = new Vector3( 0 , 0 , 0 );
			//ゴール生成用の球を発射する角度
			public static readonly Vector3 ShootAngleMin = new Vector3( -1f , -1f , 0.5f );
			public static readonly Vector3 ShootAngleMax = new Vector3( 1f , 1f , 1f );
			//球飛ばしてからゴールの位置を決めるまでのフレーム
			public const int PutGoalPosFrameMin = 15;
			public const int PutGoalPosFrameMax = 30;

		}

	}


}
