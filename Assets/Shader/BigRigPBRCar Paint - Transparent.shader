Shader "BigRig/PBR/Car Paint - Transparent" {
	Properties {
		_Color ("Base Albedo", Vector) = (1,1,1,1)
		_MainTex ("Base Albedo Texture", 2D) = "white" {}
		_AdditionalAlbedoTex ("Additional Albedo Texture", 2D) = "black" {}
		_Glossiness ("Base Smoothness", Range(0, 1)) = 0.5
		[Gamma] _Metallic ("Base Metallic", Range(0, 1)) = 0
		_MetallicGlossMap ("Base Metallic Texture", 2D) = "white" {}
		_BumpScale ("Scale", Float) = 1
		[Normal] _BumpMap ("Normal Map", 2D) = "bump" {}
		_OcclusionStrength ("Strength", Range(0, 1)) = 1
		_OcclusionMap ("Occlusion", 2D) = "white" {}
		_EmissionColor ("Color", Vector) = (0,0,0,1)
		_EmissionMap ("Emission", 2D) = "white" {}
		[NoScaleOffset] [Normal] _FlakesBumpMap ("Base Bump Flakes (normal)", 2D) = "bump" {}
		_FlakesBumpMapScale ("Base Bump Flakes Scale", Float) = 1
		_FlakesBumpStrength ("Base Bump Flakes Strength", Range(0.001, 8)) = 1
		_FlakeColor ("Base Flakes Albedo", Vector) = (1,1,1,1)
		_FlakesColorMap ("Base Flakes Albedo Texture", 2D) = "black" {}
		_FlakesColorMapScale ("Base Flakes Color Scale", Float) = 1
		_FlakesColorStrength ("Base Flakes Color Strength", Range(0, 10)) = 1
		_FlakesColorCutoff ("Base Flakes Color Cutoff", Range(0, 0.95)) = 0.5
		_FresnelColor ("Fresnel Color", Vector) = (1,1,1,1)
		_FresnelPower ("Fresnel Power", Range(0, 10)) = 1
		_ReflectionSpecularMap ("Reflection Specular Map", 2D) = "black" {}
		_ReflectionSpecular ("Reflection Specular", Vector) = (0.3,0.3,0.3,1)
		_ReflectionGlossiness ("Reflection Smoothness", Range(0, 1)) = 1
		[ToggleOff] _SpecularHighlights ("Specular Highlights", Float) = 1
		[HideInInspector] _Cull ("__cull", Float) = 2
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "BaseLWRPCustomCarPaintEditor"
}