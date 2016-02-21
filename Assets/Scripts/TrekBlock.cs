using UnityEngine;
using System.Collections;

namespace Hike
{
	public class TrekBlock : MonoBehaviour
	{
		public const float BlockWidth = 4;
		public Player Player;

		private SpriteRenderer spriteRenderer;
		private int blockIndex = -1;
		private TrekInfo.Block block;

		public int BlockIndex
		{
			get { return blockIndex; }
			set
			{
				if (value != blockIndex)
				{
					blockIndex = value;
					block = Player.CurrentTrek.Blocks [value];
					spriteRenderer.sprite = Player.CurrentLevel.GetGroundSprite( block.Type, blockIndex );
				}
			}
		}

		protected void Awake ()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		protected void LateUpdate ()
		{
			Vector3 pos = transform.localPosition;
			pos.x = (BlockIndex - Player.CurrentBlockIdx - Player.InBlockPosition) * BlockWidth;
			pos.y = 0f;
			transform.localPosition = pos;
		}
	}
}
