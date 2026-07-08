sampler2D TextureSampler : register(s0);

uniform float Time; // level.TimeActive
uniform float2 CamPos; // level.Camera.Position
uniform float2 Dimensions; // new Vector2(320, 180)
uniform int size;
uniform int UseTexturedChecker;

uniform float4x4 TransformMatrix;
uniform float4x4 ViewMatrix;

float4 magenta = float4(1,0,1, 1);
float4 black = float4(0,0,0, 1);


float4 SpritePixelShader(float4 position : SV_Position, float4 texColor: COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
	float a = texColor.a;
	if (a <= 0.0) discard;

	float2 uv = texCoord;
	float4 text = tex2D(TextureSampler, uv);
	if (text.a <= 0.0) discard;

	int fx = (int)floor(position.x / size);
	int fy = (int)floor(position.y / size);

	bool even = ((fx + fy) % 2) == 0;

	float3 checker = even ? magenta.rgb : black.rgb;

	float3 mode0Color = checker * a;
	float mode0Alpha = a;

	float mode1Alpha = text.a * a;
	float3 mode1Color = text.rgb * texColor.rgb * checker * mode1Alpha;

	float3 finalColor = lerp(mode0Color, mode1Color, (float)UseTexturedChecker);
	float finalAlpha = lerp(mode0Alpha, mode1Alpha, (float)UseTexturedChecker);

	return float4(finalColor, finalAlpha);
}

technique Shader
{
	pass pass0
	{
		PixelShader = compile ps_3_0 SpritePixelShader();
	}
}