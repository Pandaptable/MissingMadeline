using System;
using System.Collections.Generic;
using Celeste.Mod.MaxHelpingHand.Entities;

namespace Celeste.Mod.MissingMadeline.ModCompat;

public class MaddieHelpingHandCompat
{
	public static HashSet<Type> LoadEntities()
	{
		return new HashSet<Type>
		{
			(MissingMadelineModule.Settings.Interactive.ToggleSprings) ? typeof(NoDashRefillSpring) : typeof(Maddy3D),
			(MissingMadelineModule.Settings.Collectibles.ToggleStrawberries) ? typeof(SecretBerry) : typeof(Maddy3D),
			(MissingMadelineModule.Settings.Interactive.ToggleRefills) ? typeof(CustomizableRefill) : typeof(Maddy3D),
			(MissingMadelineModule.Settings.Interactive.ToggleJellyfish) ? typeof(FrozenJelly) : typeof(Maddy3D),
			(MissingMadelineModule.Settings.Interactive.TogglePufferfish) ? typeof(StaticPuffer) : typeof(Maddy3D),
			(MissingMadelineModule.Settings.Collectibles.ToggleHearts) ? typeof(ReskinnableCrystalHeart) : typeof(Maddy3D),
		};
	}
}