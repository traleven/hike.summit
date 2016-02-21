using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace Hike
{
	[Serializable]
	public class BlocksContainer
	{
		[SerializeField]
		private TrekInfo.Block[] blocks = new TrekInfo.Block[0];

		public int Length
		{
			get
			{
				return blocks.Sum((b) => b.Length);
			}
		}

		public TrekInfo.Block this[int idx]
		{
			get
			{
				if (idx < 0)
					return blocks[0];

				for (int i = 0, p = 0, n = blocks.Length; i < n; ++i)
				{
					p += blocks[i].Length;
					if (p > idx)
						return blocks[i];
				}

				return blocks[blocks.Length - 1];
			}
		}
	}
}
