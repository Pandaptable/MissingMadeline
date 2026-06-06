using System.Collections.Generic;
using Celeste.Mod.CelesteNet;
using Celeste.Mod.CelesteNet.Client;
using Celeste.Mod.CelesteNet.Client.Entities;
using Celeste.Mod.CelesteNet.DataTypes;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.MissingMadeline.ModCompat;

public class DataMissingMadelineState : DataType<DataMissingMadelineState>
{
	static DataMissingMadelineState()
	{
		DataID = "MissingMadeline/State";
	}

	public DataPlayerInfo Player;
	public bool ToggleHair;
	public bool ToggleSkin;
	public int TextureSize;

	public bool HasAnyEnabled => ToggleHair || ToggleSkin;

	public DataMissingMadelineState() { }

	public DataMissingMadelineState(DataPlayerInfo player)
	{
		Player = player;
	}

	public override bool FilterHandle(DataContext ctx)
		=> Player != null;

	public override MetaType[] GenerateMeta(DataContext ctx)
		=> new MetaType[]
		{
			new MetaPlayerPrivateState(Player),
			new MetaBoundRef(DataType<DataPlayerInfo>.DataID, Player?.ID ?? uint.MaxValue, true)
		};

	public override void FixupMeta(DataContext ctx)
	{
		Player = Get<MetaPlayerPrivateState>(ctx);
		Get<MetaBoundRef>(ctx).ID = Player?.ID ?? uint.MaxValue;
	}

	protected override void Read(CelesteNetBinaryReader reader)
	{
		ToggleHair = reader.ReadBoolean();
		ToggleSkin = reader.ReadBoolean();
		TextureSize = reader.ReadByte();
	}

	protected override void Write(CelesteNetBinaryWriter writer)
	{
		writer.Write(ToggleHair);
		writer.Write(ToggleSkin);
		writer.Write((byte)TextureSize);
	}
}

public class MissingMadelineNetComponent : CelesteNetGameComponent
{
	public static MissingMadelineNetComponent Instance { get; private set; }

	private CelesteNetClientContext ctx;
	private float sendTimer;
	private readonly Dictionary<uint, DataMissingMadelineState> playerStates = new();

	public MissingMadelineNetComponent(CelesteNetClientContext context, Game game)
		: base(context, game)
	{
		Instance = this;
		ctx = context;
	}

	public DataMissingMadelineState? GetState(Ghost ghost)
	{
		if (ghost?.PlayerInfo == null)
			return null;

		var client = ctx?.Client;
		if (client?.Data?.TryGetBoundRef<DataPlayerInfo, DataMissingMadelineState>(
			ghost.PlayerInfo.ID, out var state) == true)
			return state;

		playerStates.TryGetValue(ghost.PlayerInfo.ID, out state);
		return state;
	}

	public void Handle(CelesteNetConnection con, DataReady ready)
	{
		SendState();
	}

	public void Handle(CelesteNetConnection con, DataMissingMadelineState data)
	{
		if (data.Player != null)
			playerStates[data.Player.ID] = data;
	}

	public void SendState()
	{
		var client = ctx?.Client;
		if (client?.PlayerInfo == null)
			return;

		var settings = MissingMadelineModule.Settings;
		var data = new DataMissingMadelineState(client.PlayerInfo)
		{
			ToggleHair = settings.Player.ToggleHair,
			ToggleSkin = settings.Player.ToggleSkin,
			TextureSize = settings.Other.TextureSize,
		};

		client.Send(data);
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);

		sendTimer -= Engine.RawDeltaTime;
		if (sendTimer > 0f)
			return;
		sendTimer = 2f;

		SendState();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && Instance == this)
			Instance = null;
		base.Dispose(disposing);
	}
}
