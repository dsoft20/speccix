Shader "Speccy/sprite" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "black" {}
		_Paper ("Paper Color", 2D) = "white" {}
		_Ink ("Ink Color", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue"="Transparent+1000" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf NoLighting alpha noambient

		sampler2D _MainTex;
		sampler2D _Paper;
		sampler2D _Ink;
		
		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
		};

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
	    {
	        fixed4 c;
	        c.rgb = s.Albedo.rgb; 
	        c.a = s.Alpha;
	        return c;
	    }
		
		void surf (Input IN, inout SurfaceOutput o) {
			float2 screenUV;
			screenUV = IN.screenPos.xy / IN.screenPos.w;
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			if (c.r == 1 && c.g == 0 && c.b == 1)
			{
				c.a = 0;
			}
			
			if (c.r == 0 && c.g == 0 && c.b == 0)
			{
				c.rgb = c.rgb = tex2D(_Ink, screenUV);
			}
			
			if (c.r == 1 && c.g == 1 && c.b == 1)
			{
				c.rgb = tex2D(_Paper, screenUV);
			}
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
