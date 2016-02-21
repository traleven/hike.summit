using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

namespace Hike
{
	public sealed class GameManager : MonoBehaviour
	{
		private LevelInfo currentLevel;

		[SerializeField] private GameObject sideView;
		[SerializeField] private Player player;
		[SerializeField] private CrossroadEvent OnCrossroad;
		[SerializeField] private UnityEvent OnGameOver;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}

		public void StartNewGame()
		{
			player.CurrentLevel = currentLevel;
			player.Reset(currentLevel.EntryPoint);
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

		public void SelectPath(TrekInfo trek, TrekInfo.Crossroad[] crossroad)
		{
			if (trek == currentLevel.ExitPoint && crossroad == trek.CrossroadB)
				StopGame();
			else
				OnCrossroad.Invoke(crossroad);
		}

		public void SetTimeMultiplier(float multiplier)
		{
			Timer.TimeMultiplier = multiplier;
		}

	}

	[Serializable]
	public class CrossroadEvent : UnityEvent<TrekInfo.Crossroad[]>
	{
	}
}
