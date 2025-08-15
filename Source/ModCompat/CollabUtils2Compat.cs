using System;
using System.Collections.Generic;
using Celeste.Mod.CollabUtils2.Entities;

namespace Celeste.Mod.MissingMadeline.ModCompat;

public class CollabUtils2Compat
{


	public static HashSet<Type> LoadEntities()
	{
		return new HashSet<Type>
		{
			(MissingMadelineModule.Settings.Collectibles.ToggleHearts) ? typeof(AbstractMiniHeart) : typeof(Maddy3D)
		};
	}
}