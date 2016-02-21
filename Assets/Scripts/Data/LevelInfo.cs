using UnityEngine;
using System.Collections;

namespace Hike
{
	[CreateAssetMenu]
	public class LevelInfo : ScriptableObject
	{
		public string Name;
		public TrekInfo EntryPoint;
		public TrekInfo ExitPoint;
		public WeatherInfo Weather;

		[SerializeField] private Sprite[] defaultGroundSprites = null;
		[SerializeField] private Sprite[] grassGroundSprites = null;
		[SerializeField] private Sprite[] groundGroundSprites = null;
		[SerializeField] private Sprite[] smallStonesGroundSprites = null;
		[SerializeField] private Sprite[] bigStonesGroundSprites = null;
		[SerializeField] private Sprite[] snowGroundSprites = null;
		[SerializeField] private Sprite[] iceGroundSprites = null;

		private Sprite[][] groundSprites = null;

		protected void OnEnable ()
		{
			groundSprites = new Sprite[][]
			{
				defaultGroundSprites,
				grassGroundSprites,
				groundGroundSprites,
				smallStonesGroundSprites,
				bigStonesGroundSprites,
				snowGroundSprites,
				iceGroundSprites,
			};
		}

		public Sprite GetGroundSprite (TrekInfo.TerrainType type, int blockIdx)
		{
			Sprite[] sprites = groundSprites[(int)type];
			return sprites[sprites.Length > 1 ? Mathf.Abs((int)(blockIdx / 1.58f)) % sprites.Length : 0];
		}
	}
}
