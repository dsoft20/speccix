Shader "Speccy/sprite" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "black" {}
		_BackGround ("Background", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue"="Transparent+1000" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf NoLighting alpha

		sampler2D _MainTex;
		sampler2D _BackGround;
		
		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
		};

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
	    {
	        fixed4 c;
	        c.rgb = s.Albedo.rgb/3.35; 
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
			
			if (c.r == 1 && c.g == 1 && c.b == 1)
			{
				c.rgb = tex2D(_BackGround, screenUV)*2;
			}
			
			o.Albedo = c.rgb+0.003921568627451;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
