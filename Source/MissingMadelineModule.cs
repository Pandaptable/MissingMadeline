using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Monocle;

namespace Celeste.Mod.MissingMadeline;

public class MissingMadelineModule : EverestModule
{
	private static Effect missingEffect;
	public static MissingMadelineModule Instance { get; private set; }

	public override Type SettingsType => typeof(MissingMadelineModuleSettings);
	public static MissingMadelineModuleSettings Settings => (MissingMadelineModuleSettings)Instance._Settings;

	public override Type SessionType => typeof(MissingMadelineModuleSession);
	public static MissingMadelineModuleSession Session => (MissingMadelineModuleSession)Instance._Session;

	public override Type SaveDataType => typeof(MissingMadelineModuleSaveData);
	public static MissingMadelineModuleSaveData SaveData => (MissingMadelineModuleSaveData)Instance._SaveData;

	public MissingMadelineModule()
	{
		Instance = this;
#if DEBUG
		// debug builds use verbose logging
		Logger.SetLogLevel(nameof(MissingMadelineModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(MissingMadelineModule), LogLevel.Info);
#endif
	}

	public override void Load()
	{
		On.Celeste.PlayerHair.Render += PlayerHairRenderHook;
		On.Celeste.PlayerSprite.Render += PlayerSpriteRenderHook;
		On.Celeste.Spikes.Render += SpikesRenderHook;
		On.Celeste.Refill.Render += RefillRenderHook;
		On.Celeste.TouchSwitch.Render += TouchSwitchRenderHook;
		On.Celeste.Spring.Render += SpringRenderHook;
		On.Celeste.DreamBlock.Render += DreamBlockRenderHook;
		On.Celeste.Wire.Render += WireRenderHook;
		On.Celeste.Level.Render += LevelRenderHook;
		On.Monocle.Entity.Render += EntityRenderHook;
	}

	public override void Unload()
	{
		On.Celeste.PlayerHair.Render -= PlayerHairRenderHook;
		On.Celeste.PlayerSprite.Render -= PlayerSpriteRenderHook;
		On.Celeste.Spikes.Render -= SpikesRenderHook;
		On.Celeste.Refill.Render -= RefillRenderHook;
		On.Celeste.TouchSwitch.Render += TouchSwitchRenderHook;
		On.Celeste.Spring.Render -= SpringRenderHook;
		On.Celeste.DreamBlock.Render -= DreamBlockRenderHook;
		On.Celeste.Wire.Render -= WireRenderHook;
		On.Celeste.Level.Render -= LevelRenderHook;
		On.Monocle.Entity.Render -= EntityRenderHook;
	}

	public override void LoadContent(bool firstLoad)
	{
		base.LoadContent(firstLoad);

		var graphicsDeviceService =
			Engine.Instance.Content.ServiceProvider
					.GetService(typeof(IGraphicsDeviceService))
				as IGraphicsDeviceService;

		var asset = Everest.Content.Get("Effects/MissingMadeline/missing.cso", true);
		missingEffect = new Effect(graphicsDeviceService.GraphicsDevice, asset.Data);
	}

	private static void PlayerHairRenderHook(On.Celeste.PlayerHair.orig_Render orig, PlayerHair self)
	{
		if (Settings.Player.ToggleHair && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void PlayerSpriteRenderHook(On.Celeste.PlayerSprite.orig_Render orig, PlayerSprite self)
	{
		if (Settings.Player.ToggleSkin && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void SpikesRenderHook(On.Celeste.Spikes.orig_Render orig, Spikes self)
	{
		if (Settings.Hazards.ToggleSpikes && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void RefillRenderHook(On.Celeste.Refill.orig_Render orig, Refill self)
	{
		if (Settings.Collectibles.ToggleRefills && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void TouchSwitchRenderHook(On.Celeste.TouchSwitch.orig_Render orig, TouchSwitch self)
	{
		if (Settings.Interactive.ToggleSwitches && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void SpringRenderHook(On.Celeste.Spring.orig_Render orig, Spring self)
	{
		if (Settings.Interactive.ToggleSprings && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void DreamBlockRenderHook(On.Celeste.DreamBlock.orig_Render orig, DreamBlock self)
	{
		if (Settings.Blocks.ToggleDreamBlocks && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static void WireRenderHook(On.Celeste.Wire.orig_Render orig, Wire self)
	{
		if (Settings.Misc.ToggleWires && self != null && self.Scene != null)
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);

			orig(self);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}

	private static HashSet<Type> allowedTypes
	{
		get
		{
			return new HashSet<Type>
			{
				(Settings.Collectibles.ToggleStrawberries) ? typeof(Strawberry) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleHearts) ? typeof(HeartGem) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleHearts) ? typeof(FakeHeart) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleHearts) ? typeof(DreamHeartGem) : typeof(Maddy3D),
				(Settings.Blocks.ToggleDreamBlocks) ? typeof(DreamBlock) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(RotateSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(TrackSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(DustRotateSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(DustTrackSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(BladeRotateSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(BladeTrackSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(StarRotateSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(StarTrackSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(CrystalStaticSpinner) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSpinners) ? typeof(DustStaticSpinner) : typeof(Maddy3D),
				(Settings.Blocks.ToggleKevins) ? typeof(CrushBlock) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleFeathers) ? typeof(FlyFeather) : typeof(Maddy3D),
				(Settings.Player.ToggleBadeline) ? typeof(BadelineBoost) : typeof(Maddy3D),
				(Settings.Player.ToggleBadeline) ? typeof(FinalBoss) : typeof(Maddy3D),
				(Settings.Player.ToggleBadeline) ? typeof(FinalBossBeam) : typeof(Maddy3D),
				(Settings.Player.ToggleBadeline) ? typeof(FinalBossShot) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleKeys) ? typeof(Key) : typeof(Maddy3D),
				(Settings.Interactive.ToggleSwitches) ? typeof(Switch) : typeof(Maddy3D),
				(Settings.Hazards.ToggleLava) ? typeof(RisingLava) : typeof(Maddy3D),
				(Settings.Hazards.ToggleLava) ? typeof(SandwichLava) : typeof(Maddy3D),
				(Settings.Misc.ToggleIntroCar) ? typeof(IntroCar) : typeof(Maddy3D),
				(Settings.Interactive.TogglePufferfish) ? typeof(Puffer) : typeof(Maddy3D),
				(Settings.Hazards.ToggleFireballs) ? typeof(FireBall) : typeof(Maddy3D),
				(Settings.Hazards.ToggleSnowballs) ? typeof(Snowball) : typeof(Maddy3D),
				(Settings.Blocks.ToggleCassetteBlocks) ? typeof(CassetteBlock) : typeof(Maddy3D),
				(Settings.Collectibles.ToggleCassettes) ? typeof(Cassette) : typeof(Maddy3D),
				(Settings.Misc.ToggleBirds) ? typeof(BirdNPC) : typeof(Maddy3D),
				(Settings.Misc.ToggleBirds) ? typeof(FlingBird) : typeof(Maddy3D),
				(Settings.Misc.ToggleBirds) ? typeof(FlutterBird) : typeof(Maddy3D),
				(Settings.Misc.ToggleBirds) ? typeof(FlingBirdIntro) : typeof(Maddy3D),
				(Settings.Misc.ToggleBirds) ? typeof(BirdPath) : typeof(Maddy3D),
				(Settings.Interactive.ToggleJellyfish) ? typeof(Glider) : typeof(Maddy3D),
				(Settings.Player.ToggleTheo) ? typeof(TheoCrystal) : typeof(Maddy3D)
			};
		}
	}

	private static List<Entity> trackedEntities = new List<Entity>();

	private static void LevelRenderHook(On.Celeste.Level.orig_Render orig, Level self)
	{
		if (self.Pathfinder.DebugRenderEnabled)
		{
			orig(self); return;
		}

		if (!Settings.Misc.ToggleAllEntities)
		{
			trackedEntities = self.Entities.entities
				.Where(e => allowedTypes.Contains(e.GetType()))
				.ToList();
		}
		else
		{
			trackedEntities = self.Entities.entities
				.ToList();
		}

		orig(self);
	}

	private static void EntityRenderHook(On.Monocle.Entity.orig_Render orig, Entity self)
	{
		if (self.Scene is Level)
		{
			if (self.SceneAs<Level>().Pathfinder.DebugRenderEnabled)
			{
				orig(self);
				return;
			}
		}


		if (self != null && self.Scene != null && trackedEntities.Contains(self))
		{
			missingEffect.Parameters["size"].SetValue(Settings.Other.TextureSize);

			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, missingEffect,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
			orig(self);
			Draw.SpriteBatch.End();
			Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
				DepthStencilState.None, RasterizerState.CullNone, null,
				(self.SceneAs<Level>()).GameplayRenderer.Camera.Matrix);
		}
		else
		{
			orig(self);
		}
	}
}