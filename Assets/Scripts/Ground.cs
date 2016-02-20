using UnityEngine;
using System.Collections;

namespace Hike
{
	public class Ground : MonoBehaviour
	{
		[SerializeField] private Player player;
		[SerializeField] private TrekBlock block;

		private float currentSlope = 0f;

		private TrekBlock[] blocks;

		protected void Awake()
		{
			blocks = new TrekBlock[10];
			for (int i = 0, n = blocks.Length; i < n; ++i)
			{
				blocks[i] = Instantiate<TrekBlock>(block);
				blocks[i].transform.parent = transform;
				blocks[i].Player = player;
				blocks[i].BlockIndex = i;
			}
		}

		protected void Update()
		{
			for (int i = 0, n = blocks.Length; i < n; ++i)
			{
				blocks[i].BlockIndex = player.CurrentBlockIdx + i - n / 2;
			}
		}

		protected void LateUpdate()
		{
			var currentBlock = player.CurrentBlock;
			var rotation = transform.localRotation;
			currentSlope = Mathf.Lerp(currentSlope, currentBlock.Slope, 0.2f);
			rotation.eulerAngles = new Vector3(0f, 0f, currentSlope);
			transform.localRotation = rotation;
		}
	}
}
