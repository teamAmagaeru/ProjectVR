Shader "Custom/TestShader" 
{
	Properties{
		_Color("Color", Color) = (1, 1, 1, 0.5)
	}
	SubShader{
		Pass{
			Tags{ "Queue" = "Transparent" }
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha //標準的なアルファブレンディング

			CGPROGRAM
			#pragma vertex vert 
			#pragma fragment frag
#include "UnityCG.cginc"

			fixed4 _Color;

			struct Input {
				float4 vertex : POSiTION;
				float3 normal : NORMAL;
			};
			struct v2f {
				float4 position : SV_POSITION;
				float3 normalDirection : TEXCOORD0;
				float3 viewDirection : TEXCOORD1;
			};


			v2f vert(Input input){
				v2f o;

				float4x4 modelMatrix = _Object2World;
				float4x4 modelMatrixInverse = _World2Object;

				float3 normalDirection = normalize(mul(input.normal, modelMatrixInverse)).xyz;
				float3 viewDirection = normalize(_WorldSpaceCameraPos - mul(modelMatrix, input.vertex).xyz);

				o.position = mul(UNITY_MATRIX_MVP, input.vertex);
				o.normalDirection = normalDirection;
				o.viewDirection = viewDirection;

				return o;
			}

			fixed4 frag(v2f i) : COLOR{
				float3 normalDirection = normalize(i.normalDirection);
				float3 viewDirection = normalize(i.viewDirection);

				float newOpacity = min(1.0, _Color.a / abs(dot(viewDirection, normalDirection)));

				return float4(_Color.rgb, newOpacity);
			}
			ENDCG
		}
	}
}
