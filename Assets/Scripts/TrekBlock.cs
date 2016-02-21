using UnityEngine;
using System.Collections;

namespace Hike
{
	public class TrekBlock : MonoBehaviour
	{
		public Player Player;

		private SpriteRenderer spriteRenderer;
		private int blockIndex;
		private TrekInfo.Block block;

		public int BlockIndex
		{
			get { return blockIndex; }
			set
			{
				blockIndex = value;
				block = Player.CurrentTrek.Blocks [value];
				spriteRenderer.sprite = Player.CurrentTrek.GetGroundSprite( block.Type );
			}
		}

		protected void Awake ()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		protected void LateUpdate ()
		{
			Vector3 pos = transform.localPosition;
			pos.x = (BlockIndex - Player.CurrentBlockIdx - Player.InBlockPosition) * 4;
			pos.y = 0f;
			transform.localPosition = pos;
		}
	}
}
