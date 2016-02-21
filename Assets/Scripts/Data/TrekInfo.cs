﻿using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace Hike
{
	[CreateAssetMenu]
	public class TrekInfo : ScriptableObject
	{
		public BlocksContainer Blocks;
		[HideInInspector]
		public TrekInfo[] CrossroadA;
		public TrekInfo[] CrossroadB;
		public Sprite[] GroundSprites;

		protected void OnEnable()
		{
			for (int i = 0, n = CrossroadB.Length; i < n; ++i)
			{
				TrekInfo other = CrossroadB[i];
				if (!other.CrossroadA.Contains(this))
					other.CrossroadA = other.CrossroadA.Concat(new TrekInfo[] { this }).ToArray();
			}
		}

		public Sprite GetGroundSprite(TerrainType type)
		{
			return GroundSprites[(int)type];
		}

		[Serializable]
		public class Block
		{
			public int Length = 1;
			public TerrainType Type;
			public float Slope;

			public Vector2[] Windy = new Vector2[4];
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
