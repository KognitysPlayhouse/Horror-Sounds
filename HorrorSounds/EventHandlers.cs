using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;
using System;
using MEC;
using System.Collections.Generic;

namespace HorrorSounds
{
	public class EventHandler
	{
		public HorrorSounds plugin;
		public EventHandler(HorrorSounds plugin) => this.plugin = plugin;
		Config Configs = HorrorSounds.HorrorSoundsRef.Config;

		public void OnRoundStartEvent()
		{
			Timing.RunCoroutine(RoundLoop(), "HorrorSoundLoop");
		}

		public void OnEndingRoundEvent(EndingRoundEventArgs ev)
		{
			if (ev.IsRoundEnded)
			{
				Timing.KillCoroutines("HorrorSoundLoop");
			}
		}

		private IEnumerator<float> RoundLoop()
		{
			System.Random numGen = new System.Random();
			int time;
			List<String> voiceLines = new List<string> { "pitch_0.1 SCP pitch_0.1 6 pitch_0.1 8 pitch_0.1 2", "pitch_0.1 scpsubjects", "pitch_0.1 Camera", "pitch_0.1 Celsius", "pitch_0.1 .g7 h h", "pitch_0.1 ContainedSuccessfully", "pitch_0.1 Decontamination", "pitch_0.1 Intersection", "pitch_0.1 NineTailedFox", "pitch_0.1 Personnel h h a c s e", "pitch_0.1 HasEntered", "pitch_0.1 e s s", "pitch_0.1 c c h", "pitch_0.1 ChaosInsurgency" };

			while (true)
			{
				time = numGen.Next(Configs.minimumTime, Configs.maximumTime);
				yield return Timing.WaitForSeconds(time);
				Cassie.Message(voiceLines[numGen.Next(voiceLines.Count)], true, false);
			}
		}
	}
}