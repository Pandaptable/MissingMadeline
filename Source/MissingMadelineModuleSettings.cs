namespace Celeste.Mod.MissingMadeline;

public class MissingMadelineModuleSettings : EverestModuleSettings {
    [SettingName("Toggle Hair")]
    [SettingSubText("Toggle missing texture for the hair (smh+ support depends on if colorgrades are used)")]
    public bool ToggleHair { get; private set; } = false;
    [SettingName("Toggle Skin")]
    [SettingSubText("Toggle missing texture for the skin (smh+ support depends on if colorgrades are used)")]
    public bool ToggleSkin { get; private set; } = false;
    
    [SettingName("Toggle Spikes")]
    [SettingSubText("Toggle missing texture for spikes")]
    public bool ToggleSpikes { get; private set; } = false;
    
    [SettingName("Toggle Refill Gems")]
    [SettingSubText("Toggle missing texture for the refill gems")]
    public bool ToggleRefills { get; private set; } = false;
    
    [SettingName("Toggle Springs")]
    [SettingSubText("Toggle missing texture for springs")]
    public bool ToggleSprings { get; private set; } = false;
    
    [SettingName("Toggle Strawberries")]
    [SettingSubText("Toggle missing texture for strawberries")]
    public bool ToggleStrawberries { get; private set; } = false;

    [SettingRange(min: 1, max: 50)] public int TextureSize { get; set; } = 3;
}