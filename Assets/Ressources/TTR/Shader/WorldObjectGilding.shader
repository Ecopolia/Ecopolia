Shader "WorldObjectGilding" {
	Properties {
		_ShineSpeed ("ShineSpeed", Range(0, 2)) = 0.1
		_MainTexture ("MainTexture", 2D) = "white" {}
		_node_9218 ("node_9218", Vector) = (1,1,1,1)
		_slant ("slant", Float) = 0.45
		_ShineInterval ("ShineInterval", Float) = 5
		_ShineWidth ("ShineWidth", Float) = 0.1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ShaderForgeMaterialInspector"
}