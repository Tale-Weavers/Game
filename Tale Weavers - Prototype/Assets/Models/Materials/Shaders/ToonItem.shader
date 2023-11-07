Shader "Unlit/ToonItem"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Albedo("Albedo", Color) = (1,1,1,1)
        _Shades("Shades", Range(1,20)) = 3
    }
    SubShader
    {    
        Tags { "RenderType" = "Opaque" }
        LOD 100


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag  

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 worldNormal: TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Albedo;
            float _Shades;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.uv = v.texcoord;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);

                //Coseno entre el vector de normal y la dirección de la luz
                float cosineAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));

                cosineAngle = max(cosineAngle, 0.0);

                cosineAngle = floor(cosineAngle * _Shades) / _Shades + 0.3;

                return col * cosineAngle;
            }
            ENDCG
        }

    }
}
