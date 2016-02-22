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
		[SerializeField] private Camp camp;
		[SerializeField] private CrossroadInfoEvent OnCrossroadInfo;
		[SerializeField] private CrossroadEvent OnCrossroad;
		[SerializeField] private UnityEvent OnGameOver;
        [SerializeField] private ResultsWindow resultsWindow;

		public void SetLevel(LevelInfo level)
		{
			currentLevel = level;
		}

		public void StartNewGame()
		{
			player.CurrentLevel = currentLevel;
			player.Reset(currentLevel.EntryPoint);
			Timer.TimeMultiplier = 1f;
			sideView.SetActive(true);
		}

		public void Resume()
		{
			sideView.SetActive(true);
			player.gameObject.SetActive(true);
			camp.gameObject.SetActive(false);
		}

		public void StopGame(bool win)
		{
            resultsWindow.SetupResults(win);
			sideView.SetActive(false);
			OnGameOver.Invoke();
		}

		public void Break()
		{
			player.gameObject.SetActive(false);
			camp.gameObject.SetActive(true);
		}

		public void SelectPath(TrekInfo trek, TrekInfo.Crossroad[] crossroad)
		{
			if (trek == currentLevel.ExitPoint && crossroad == trek.CrossroadB)
				StopGame(true);
			else
			{
				sideView.SetActive(false);
				OnCrossroadInfo.Invoke(trek.CrossroadA == crossroad ? trek.CrossroadAInfo : trek.CrossroadBInfo);
				OnCrossroad.Invoke(crossroad);
			}
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

	[Serializable]
	public class CrossroadInfoEvent : UnityEvent<CrossroadInfo>
	{
	}
}
