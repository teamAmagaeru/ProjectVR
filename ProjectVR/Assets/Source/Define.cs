using UnityEngine;
using System.Collections;

/// <summary>
/// 調整値のまとめ.
/// </summary>
static public class Define{

    //---------------------コントローラー系---------------------//S
    static public class Controller
    {
        // ボールチャージ(もう使ってない).
        public const float  ChargeTime = 3.0f;               // 長押しの最大時間.
        public const ushort ChargeVibrationValueMin = 500;   // 長押しの最低振動.
        public const ushort ChargeVibrationValueMax = 2000;  // 長押しの最大振動.
        // ボールチャージ(レベルが変わったとき).
        public const ushort LevelChangeVibrationValue = 1000;   // レベル変更時の振動.
        public const float LevelChangeVibrationTime = 0.3f;     // レベル変更時の振動時間(sec).
        // チャージリセット.
        public const ushort ChangeResetVibrationValue = 1000;   // チャージリセット時の振動.
        public const float ChangeResetVibrationTime = 0.5f;     // チャージリセット時の振動時間(sec).
        // ボール発射.
        public const ushort ShootVibrationValue = 1000;      // ボール発射時の振動強度.
        public const float  ShootVibrationTime = 0.1f;       // ボール発射時の振動時間(sec).
    }
    //---------------------コントローラー系---------------------//E

    //---------------------シューター系---------------------//S
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
            // 0秒は必須.
            new Charge(0.0f, 300.0f , 180),
            new Charge(1.0f, 600.0f , 180),
            new Charge(2.0f, 900.0f , 180),
            new Charge(3.0f, 1500.0f , 180),
        };
        public static float ChargeResetTime = 5.0f;    // チャージリセット時間(sec).

		//予測用の球関係のデータ
		public static class OrbitPLan
		{
			//球を飛ばす感覚
			public const int ShootFrame = 10;
			//球が消えるフレーム
			public const int BallDeleteFrame = 60;
		}

    }
    //---------------------シューター系---------------------//E

    //---------------------UI系---------------------//S
    static public class UI {
        // ウェーブの文字.
        public const string waveTextLeft = "wave ";
        public const string waveTextRight = "";
        // 追加点の文字.
        public const string addScoreTextLeft = "+";
        public const string addScoreTextRight = "";
        // シュート時の評価.
        public class ShootResult {
            public int bound;   // バウンド回数.
            public string text; // 文字列.
            public Color color; // 色.
            public ShootResult(int in_bound, string in_text, Color in_color)
            {
                bound = in_bound;
                text = in_text;
                color = in_color;
            }
        }
        public static ShootResult[] shootResults = new ShootResult[]
        {
            // 0回は必須.
            new ShootResult(0,"dummy",Color.black),
            new ShootResult(1,"OK",Color.black),
            new ShootResult(2,"good",Color.black),
            new ShootResult(3,"Great",Color.green),
            new ShootResult(4,"Perfect",Color.red),
        };
    }

    //---------------------UI系---------------------//E

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


		public static readonly Vector3 StateChangeObjPos = new Vector3(0f,1.5f,2f);

	}


}
