using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        On.Celeste.Spring.Render += SpringRenderHook;
        On.Celeste.Level.Render += LevelRenderHook;
        On.Monocle.Entity.Render += EntityRenderHook;
    }

    public override void Unload()
    {
        On.Celeste.PlayerHair.Render -= PlayerHairRenderHook;
        On.Celeste.PlayerSprite.Render -= PlayerSpriteRenderHook;
        On.Celeste.Spikes.Render -= SpikesRenderHook;
        On.Celeste.Refill.Render -= RefillRenderHook;
        On.Celeste.Spring.Render -= SpringRenderHook;
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
        if (Settings.ToggleHair && self != null && self.Scene != null)
        {
            
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);

            orig(self);

            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }

    private static void PlayerSpriteRenderHook(On.Celeste.PlayerSprite.orig_Render orig, PlayerSprite self)
    {
        if (Settings.ToggleSkin && self != null && self.Scene != null)
        {
            
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);

            orig(self);

            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }

    private static void SpikesRenderHook(On.Celeste.Spikes.orig_Render orig, Spikes self)
    {
        if (Settings.ToggleSpikes && self != null && self.Scene != null)
        {
            
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);

            orig(self);

            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }

    private static void RefillRenderHook(On.Celeste.Refill.orig_Render orig, Refill self)
    {
        if (Settings.ToggleRefills && self != null && self.Scene != null)
        {
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);

            orig(self);

            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }

    private static void SpringRenderHook(On.Celeste.Spring.orig_Render orig, Spring self)
    {
        if (Settings.ToggleSprings && self != null && self.Scene != null)
        {
            
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);

            orig(self);

            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }

    private static readonly HashSet<Type> allowedTypes = new HashSet<Type>
    {
        typeof(Strawberry),
        typeof(HeartGem),
        typeof(FakeHeart)
    };

    private static List<Entity> trackedEntities = new List<Entity>();

    private static void LevelRenderHook(On.Celeste.Level.orig_Render orig, Level self)
    {
        trackedEntities = self.Entities.entities
            .Where(e => allowedTypes.Contains(e.GetType()))
            .ToList();

        orig(self);
    }

    private static void EntityRenderHook(On.Monocle.Entity.orig_Render orig, Entity self)
    {
        if (self != null && self.Scene != null && trackedEntities.Contains(self))
        {
            missingEffect.Parameters["size"].SetValue(Settings.TextureSize);
            
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, missingEffect,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
            orig(self);
            Draw.SpriteBatch.End();
            Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap,
                DepthStencilState.None, RasterizerState.CullNone, null,
                (self.Scene as Level).GameplayRenderer.Camera.Matrix);
        }
        else
        {
            orig(self);
        }
    }
    
}