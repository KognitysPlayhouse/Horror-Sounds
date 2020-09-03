using System;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace HorrorSounds
{
	public sealed class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		public int minimumTime { get; set; } = 60;
		public int maximumTime { get; set; } = 120;
	}
}