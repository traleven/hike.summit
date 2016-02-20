using UnityEngine;
using System.Collections;

namespace Hike
{
	public sealed class GameManager : MonoBehaviour
	{
		private LevelInfo currentLevel;

		[SerializeField] private Player player;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}

		public void StartNewGame()
		{
			player.Reset(currentLevel.EntryPoint);
			player.enabled = true;
		}

		public void SelectPath(TrekInfo[] crossroad)
		{
			player.enabled = false;
		}
	}
}
