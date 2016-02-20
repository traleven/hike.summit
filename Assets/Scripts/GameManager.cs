using UnityEngine;
using System.Collections;

namespace Hike
{
	public sealed class GameManager : MonoBehaviour
	{
		private LevelInfo currentLevel;

		[SerializeField] private GameObject sideView;
		[SerializeField] private Player player;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}

		public void StartNewGame()
		{
			player.Reset(currentLevel.EntryPoint);
			player.enabled = true;
			sideView.SetActive(true);
		}

		public void Resume()
		{
			sideView.SetActive(true);
		}

		public void StopGame()
		{
			sideView.SetActive(false);
		}

		public void Break()
		{
			sideView.SetActive(false);
		}

		public void SelectPath(TrekInfo[] crossroad)
		{
			player.enabled = false;
		}
	}
}
