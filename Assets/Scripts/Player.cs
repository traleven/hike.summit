using UnityEngine;
using System.Collections;

namespace Hike
{
	public class Player : MonoBehaviour
	{
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

		[SerializeField] private GameManager gameManager;
        [SerializeField] private StatsManager statsManager;

		public void Reset(TrekInfo entryPoint)
		{
			CurrentTrek = entryPoint;
			CurrentBlockIdx = 0;
			TrekDirection = 1;
			InBlockPosition = 0.5f;
		}

		protected void Update()
		{
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

            if (null != statsManager)
                statsManager.UpdateStats();
		}
	}
}
