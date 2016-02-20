using UnityEngine;
using System.Collections;

namespace Hike
{
	public sealed class GameManager : MonoBehaviour
	{
		private LevelInfo currentLevel;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}
	}
}
