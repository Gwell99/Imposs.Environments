﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/AsciiArtColor" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	    _SegmentX ("Segment X", float) = 20
	    _SegmentY ("Segment Y", float) = 20
		_SampleTex ("Sample (Alpha)", 2D) = "white" {}
		_SampleNumber ("Sample number", int) = 8
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
	Pass {  
	ZTest Always
	ZWrite Off
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _SampleTex;
			float _SegmentX;
			float _SegmentY;
			int _SampleNumber;

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			float3 convertRGBtoHSV(float3 rgbColor) {
    float r = rgbColor[0];
    float g = rgbColor[1];
    float b = rgbColor[2];
    float colorMax = max(max(r,g), b);
    float colorMin = min(min(r,g), b);
    float delta = colorMax - colorMin;
    float h = 0.0;
    float s = 0.0;
    float v = colorMax;
    float3 hsv = float3(0,0,0);
    if (colorMax != 0.0) {
      s = (colorMax - colorMin ) / colorMax;
    }
    if (delta != 0.0) {
        if (r == colorMax) {
            h = (g - b) / delta;
        } else if (g == colorMax) {        
            h = 2.0 + (b - r) / delta;
        } else {    
            h = 4.0 + (r - g) / delta;
        }
        h *= 60.0;
        if (h < 0.0) {
            h += 360.0;
        }
    }
    hsv[0] = h;
    hsv[1] = s;
    hsv[2] = v;
    return hsv;
}

			fixed4 frag (v2f i) : COLOR
			{
				float2 uv = i.texcoord;
				uv.x = floor(uv.x*_SegmentX)/_SegmentX;
				uv.y = floor(uv.y*_SegmentY)/_SegmentY;
				fixed4 col = tex2D(_MainTex, uv+float2(.5/_SegmentX,.5/_SegmentY));
				float3 hsv = convertRGBtoHSV(col.rgb);
				uv = i.texcoord-uv;
				uv.x=(uv.x*_SegmentX*.98+.01)/_SampleNumber;
				uv.y=(uv.y*_SegmentY*.98+.01);
				float c = floor(hsv[2]*(_SampleNumber-0.002))/_SampleNumber;
				col = (col+0.005)/(hsv[2]+0.005)*tex2D(_SampleTex, uv+float2(c,0));
				return col;
			}
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
