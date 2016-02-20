using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Hike
{
	public sealed class GameManager : MonoBehaviour
	{
		private LevelInfo currentLevel;

		[SerializeField] private GameObject sideView;
		[SerializeField] private Player player;
		[SerializeField] private UnityEngine.Events.UnityEvent OnGameOver;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}

		public void StartNewGame()
		{
			player.Reset(currentLevel.EntryPoint);
			player.enabled = true;
			sideView.SetActive(true);
			Timer.TimeMultiplier = 1f;
		}

		public void Resume()
		{
			sideView.SetActive(true);
		}

		public void StopGame()
		{
			sideView.SetActive(false);
			OnGameOver.Invoke();
		}

		public void Break()
		{
			sideView.SetActive(false);
		}

		public void SelectPath(TrekInfo trek, TrekInfo[] crossroad)
		{
			player.enabled = false;
			if (trek == currentLevel.ExitPoint && crossroad == trek.CrossroadB)
				StopGame();
		}

		public void SetTimeMultiplier(float multiplier)
		{
			Timer.TimeMultiplier = multiplier;
		}
	}
}
