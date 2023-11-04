Shader "Unlit/ShaderTest1"
{
    Properties
    {
        _Albedo("Albedo", Color) = (1,1,1,1)
        _Shades("Shades", Range(1,20)) = 3
        _OutColor("Outline Color", Color) = (1,1,1,1)
        _OutValue("Outline Value", Range(0,0.2)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        //TEXTURE

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag  

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal: NORMAL;
            };

            struct v2f
            {
                float3 worldNormal: TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Albedo;
            float _Shades;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {



                //Coseno entre el vector de normal y la dirección de la luz
                float cosineAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));

                cosineAngle = max(cosineAngle, 0.0);

                cosineAngle = floor(cosineAngle * _Shades) / _Shades + 0.3;

                return _Albedo * cosineAngle;
            }
            ENDCG
        }
    }
}
