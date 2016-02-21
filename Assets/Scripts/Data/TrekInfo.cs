using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace Hike
{
	[CreateAssetMenu]
	public class TrekInfo : ScriptableObject
	{
		public BlocksContainer Blocks;

		public Sprite CrossroadASprite;
		public Sprite CrossroadBSprite;

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

			public Vector2[] Windy = new Vector2[4];
			[Multiline]
			public float[] TemperatureModifier = new float[4];
			public float[] HumidityModifier = new float[4];
			public float[] SunModifier = new float[4];

			public override string ToString ()
			{
				return string.Format ("[Block]");
			}
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
