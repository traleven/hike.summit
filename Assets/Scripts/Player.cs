using UnityEngine;
using System.Collections;

namespace Hike
{
	public class Player : MonoBehaviour
	{
		public LevelInfo CurrentLevel;
		public TrekInfo CurrentTrek;
		public int TrekDirection;
		public int CurrentBlockIdx;
		public TrekInfo.Block CurrentBlock
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
		public float InBlockPosition;

		public float CurrentSpeed;

		[SerializeField] private GameManager gameManager = null;
		[SerializeField] private SpriteRenderer spriteRenderer = null;

		public void Reset(TrekInfo entryPoint)
		{
			GoTo(entryPoint, 1);
		}

		public void GoTo(TrekInfo trek, int direction)
		{
			CurrentTrek = trek;
			TrekDirection = direction;
			CurrentBlockIdx = direction > 0 ? 0 : CurrentTrek.Blocks.Length - 1;
			InBlockPosition = 0.5f;
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
		}
	}
}
