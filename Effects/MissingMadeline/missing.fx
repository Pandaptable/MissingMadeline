sampler2D TextureSampler : register(s0);

uniform float Time; // level.TimeActive
uniform float2 CamPos; // level.Camera.Position
uniform float2 Dimensions; // new Vector2(320, 180)
uniform int size;

uniform float4x4 TransformMatrix;
uniform float4x4 ViewMatrix;

float4 magenta = float4(1,0,1, 1);
float4 black = float4(0,0,0, 1);


float4 SpritePixelShader(float4 position : SV_Position, float4 texColor: COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
	float4 text = tex2D(TextureSampler, texCoord)*texColor;

	if (text.a < 0.9)
		return float4(0, 0, 0, 0);

	// if (text.r >= 0.75 && (text.g + text.b) <= 0.25)
	// {

		int fx = (int)floor(position.x / size);
		int fy = (int)floor(position.y / size);

		bool even = ((fx + fy) % 2) == 0;

		texColor = even ? magenta : black;
	// }

	return texColor;
}




technique Shader
{
	pass pass0
	{
		PixelShader = compile ps_3_0 SpritePixelShader();
	}
}