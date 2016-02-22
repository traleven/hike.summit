using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace Hike
{
	[CreateAssetMenu]
	public class TrekInfo : ScriptableObject
	{
		public Sprite Background;
		public BlocksContainer Blocks;

		public CrossroadInfo CrossroadAInfo;
		public CrossroadInfo CrossroadBInfo;

		public Crossroad[] CrossroadA;
		public Crossroad[] CrossroadB;

		protected void OnEnable()
		{
		}

		[Serializable]
		public class Crossroad
		{
			public TrekInfo Trek;
			[Range(-1, 1)] public int Direction;
			public string RouteName;
		}

		[Serializable]
		public class Block
		{
			public int Length = 1;
			public TerrainType Type;
			public float Slope;

			public float Windy = 0f;
			public float TemperatureModifier = 1f;
			public float HumidityModifier = 1f;
			public float SunModifier = 1f;
		}

		public enum TerrainType
		{
			Default,
			Grass,
			Ground,
			SmallStones,
			BigStones,
			Snow,
			Ice,
		}
	}
}
