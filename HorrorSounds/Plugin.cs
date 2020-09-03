using System;
using System.Linq;
using Exiled.API.Features;
using UnityEngine;

namespace HorrorSounds
{
	public class HorrorSounds : Plugin<Config>
	{

		public static HorrorSounds HorrorSoundsRef { get; private set; }
		public override string Name => nameof(HorrorSounds);
		public override string Author => "Kognity";
		public EventHandler Handler;

		public HorrorSounds()
		{
			HorrorSoundsRef = this;
		}

		public override void OnEnabled()
		{
			Log.Info("HorrorSounds Plugin Enabled!");
			Log.Info("Thanks for installing my plugin <3 - Kognity");
		

			Handler = new EventHandler(this);
			Exiled.Events.Handlers.Server.RoundStarted += Handler.OnRoundStartEvent;
			Exiled.Events.Handlers.Server.EndingRound += Handler.OnEndingRoundEvent;
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Server.RoundStarted -= Handler.OnRoundStartEvent;
			Exiled.Events.Handlers.Server.EndingRound -= Handler.OnEndingRoundEvent;
			Handler = null;
		}

		public override void OnReloaded() { }
	}
}