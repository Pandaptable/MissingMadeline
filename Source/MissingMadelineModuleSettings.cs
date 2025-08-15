namespace Celeste.Mod.MissingMadeline;

public class MissingMadelineModuleSettings : EverestModuleSettings
{

	public PlayerSettings Player { get; set; } = new();
	public HazardSettings Hazards { get; set; } = new();
	public BlockSettings Blocks { get; set; } = new();
	public CollectibleSettings Collectibles { get; set; } = new();
	public InteractiveSettings Interactive { get; set; } = new();
	public MiscSettings Misc { get; set; } = new();
	public OtherSettings Other { get; set; } = new();


	[SettingSubMenu]
	public class PlayerSettings
	{
		[SettingName("Toggle Hair")]
		[SettingSubText("(smh+ support depends on if colorgrades are used)")]
		public bool ToggleHair { get; set; } = false;

		[SettingName("Toggle Skin")]
		[SettingSubText("(smh+ support depends on if colorgrades are used)")]
		public bool ToggleSkin { get; set; } = false;

		[SettingName("Toggle Badeline")]
		[SettingSubText("Anything badeline related")]
		public bool ToggleBadeline { get; set; } = false;

		[SettingName("Toggle Theo")]
		[SettingSubText("(crystals only)")]
		public bool ToggleTheo { get; set; } = false;
	}


	[SettingSubMenu]
	public class HazardSettings
	{
		[SettingName("Toggle Spikes")]
		public bool ToggleSpikes { get; set; } = false;

		[SettingName("Toggle Spinners")]
		[SettingSubText("Dust bunnies, crystal spinners, farewell stars, etc.")]
		public bool ToggleSpinners { get; set; } = false;

		[SettingName("Toggle Lava")]
		[SettingSubText("Includes ice variant")]
		public bool ToggleLava { get; set; } = false;

		[SettingName("Toggle Fireballs")]
		[SettingSubText("Includes ice balls (chapter 8)")]
		public bool ToggleFireballs { get; set; } = false;

		[SettingName("Toggle Snowballs")]
		[SettingSubText("(like in chapter 4)")]
		public bool ToggleSnowballs { get; set; } = false;
	}


	[SettingSubMenu]
	public class BlockSettings
	{
		[SettingName("Toggle Kevins")]
		public bool ToggleKevins { get; set; } = false;

		[SettingName("Toggle Cassette Blocks")]
		public bool ToggleCassetteBlocks { get; set; } = false;

		[SettingName("Toggle Dream Blocks")]
		public bool ToggleDreamBlocks { get; set; } = false;
	}


	[SettingSubMenu]
	public class CollectibleSettings
	{
		[SettingName("Toggle Golden Feathers")]
		public bool ToggleFeathers { get; set; } = false;

		[SettingName("Toggle Refill Gems")]
		public bool ToggleRefills { get; set; } = false;

		[SettingName("Toggle Strawberries")]
		public bool ToggleStrawberries { get; set; } = false;

		[SettingName("Toggle Keys")]
		public bool ToggleKeys { get; set; } = false;

		[SettingName("Toggle Crystal Hearts")]
		[SettingSubText("Also applies to fake hearts")]
		public bool ToggleHearts { get; set; } = false;

		[SettingName("Toggle Cassettes")]
		public bool ToggleCassettes { get; set; } = false;
	}


	[SettingSubMenu]
	public class InteractiveSettings
	{
		[SettingName("Toggle Springs")]
		public bool ToggleSprings { get; set; } = false;

		[SettingName("Toggle Pufferfish")]
		public bool TogglePufferfish { get; set; } = false;

		[SettingName("Toggle Jellyfish")]
		public bool ToggleJellyfish { get; set; } = false;

		[SettingName("Toggle Switches")]
		public bool ToggleSwitches { get; set; } = false;
	}


	[SettingSubMenu]
	public class MiscSettings
	{
		[SettingName("Toggle Wires")]
		public bool ToggleWires { get; set; } = false;
		
		[SettingName("Toggle Birds")]
		public bool ToggleBirds { get; set; } = false;
		
		[SettingName("Toggle Intro Car")]
		public bool ToggleIntroCar { get; set; } = false;

		[SettingName("Toggle All Entities")]
		[SettingSubText("This will break.")]
		public bool ToggleAllEntities { get; set; } = false;
	}


	[SettingSubMenu]
	public class OtherSettings
	{
		[SettingRange(min: 1, max: 50)]
		public int TextureSize { get; set; } = 3;
	}
}
