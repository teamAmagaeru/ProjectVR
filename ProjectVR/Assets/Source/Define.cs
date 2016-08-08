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
            public Charge(float time, float speed)
            {
                Time = time;
                Speed = speed;
            }
        }
        // チャージ.
        public static Charge[] ChargeSetting = new Charge[] {
            // 0秒は必須.
            new Charge(0.0f, 300.0f),
            new Charge(0.5f, 600.0f),
            new Charge(1.0f, 900.0f),
            new Charge(1.5f, 1500.0f),
        };

		//予測用の球関係のデータ
		public static class OrbitPLan
		{
			//球を飛ばす感覚
			public const int shoot_frame = 10;
			//球が消えるフレーム
			public const int ball_delete_frame = 60;
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
			public static readonly Vector3 shoot_pos = new Vector3( 0 , 0 , 0 );
			//ゴール生成用の球を発射する角度
			public static readonly Vector3 shoot_angle_min = new Vector3( -1f , -1f , 0.5f );
			public static readonly Vector3 shoot_angle_max = new Vector3( 1f , 1f , 1f );
			//球飛ばしてからゴールの位置を決めるまでのフレーム
			public const int put_goal_pos_frame_min = 15;
			public const int put_goal_pos_frame_max = 30;

		}

	}

}
