﻿using UnityEngine;
using System.Collections;

namespace Hike
{
	public class Player : MonoBehaviour
	{
		[HideInInspector] public LevelInfo CurrentLevel;
		[HideInInspector] public TrekInfo CurrentTrek;
		[HideInInspector] public int TrekDirection;
		[HideInInspector] public int CurrentBlockIdx;
		[HideInInspector] public TrekInfo.Block CurrentBlock
		{
			get
			{
				if (CurrentBlockIdx < 0)
					return CurrentTrek.Blocks[0];
				if (CurrentBlockIdx >= CurrentTrek.Blocks.Length)
					return CurrentTrek.Blocks[CurrentTrek.Blocks.Length - 1];
				return CurrentTrek.Blocks[CurrentBlockIdx];
			}
		}
		[HideInInspector] public float InBlockPosition;

		public float CurrentSpeed;

        public float backScrollSpeed = 1f;

		[SerializeField] private GameManager gameManager = null;
		[SerializeField] private SpriteRenderer spriteRenderer = null;
		[SerializeField] private Window gameplayWindow = null;
		[SerializeField] private StatsManager stats = null;
		[SerializeField] private HUD hud;

		public void Reset(TrekInfo entryPoint)
		{
			GoTo(entryPoint, 1);
			hud.InitHUD(stats);
			stats.Reset();
			hud.UpdateStatsHud(stats);
		}

		public void GoTo(TrekInfo trek, int direction)
		{
			CurrentTrek = trek;
			TrekDirection = direction;
			CurrentBlockIdx = direction > 0 ? 0 : CurrentTrek.Blocks.Length - 1;
			InBlockPosition = 0.5f;

			gameplayWindow.Background = trek.Background;
		}

		protected void Update()
		{
			spriteRenderer.flipX = TrekDirection < 0;
			InBlockPosition += TrekDirection * CurrentSpeed * Timer.GameDeltaTime;

			if (InBlockPosition > 1f)
			{
				CurrentBlockIdx += 1;
				InBlockPosition -= 1;
			}
			else if (InBlockPosition < 0f)
			{
				CurrentBlockIdx -= 1;
				InBlockPosition += 1;
			}

			if (CurrentBlockIdx >= CurrentTrek.Blocks.Length)
			{
				gameManager.SelectPath(CurrentTrek, CurrentTrek.CrossroadB);
			}
			else if (CurrentBlockIdx < 0)
			{
				gameManager.SelectPath(CurrentTrek, CurrentTrek.CrossroadA);
			}
			else
			{
				stats.TickWalking(Timer.GameDeltaTime, this);
			}

            var backUVrect = BackgroundManager.Instance.ActiveBG.uvRect;
            backUVrect.x += backScrollSpeed * TrekDirection * CurrentSpeed * Timer.GameDeltaTime;
            BackgroundManager.Instance.ActiveBG.uvRect = backUVrect;
		}
	}
}
