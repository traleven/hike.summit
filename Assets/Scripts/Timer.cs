using UnityEngine;
using System.Collections;

namespace Hike
{
	public static class Timer
	{
		public static float TimeMultiplier = 1f;

		public static float GameDeltaTime
		{
			get { return Time.deltaTime * TimeMultiplier; }
		}
	}
}
