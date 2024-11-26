Shader "Unlit/UIVignette"
{
        Properties
        {
            _VignetteColor("Vignette Color", Color) = (0,0,0,0)
            _VignetteIntensity("Vignette Intensity", Range(0,1)) = 0.5
            _VignetteSize("Vignette Size", Range(0,1)) = 0.5
        }
            SubShader
        {
        Tags { "Queue" = "Overlay" "RenderType" = "Opaque" }

        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

        // Texture samplers
        sampler2D _MainTex;
        float4 _VignetteColor;
        float _VignetteIntensity;
        float _VignetteSize;

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;
            return o;
        }

        half4 frag(v2f i) : SV_Target
        {
            // Calculate the distance from the center of the screen (0.5, 0.5)
            float2 center = float2(0.5, 0.5);
            float2 diff = i.uv - center;
            float dist = length(diff);

            // Apply vignette based on distance from center
            float vignette = smoothstep(1.0 - _VignetteSize, 1.0, dist);

            // Apply the vignette color and intensity
            half4 col = _VignetteColor * vignette * _VignetteIntensity;
            col.a = vignette * _VignetteIntensity;

            return col;
        }
        ENDCG
        }
    }

        Fallback "Unlit/Color"
}