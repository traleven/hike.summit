using UnityEngine;
using System.Collections;

namespace Hike
{
	public class CrossroadSign : MonoBehaviour
	{
		[SerializeField] private Player player;
		[SerializeField] [Range(0, 1)] private int end;

		protected void LateUpdate ()
		{
			Vector3 pos = transform.localPosition;
			pos.x = (player.CurrentTrek.Blocks.Length * end - player.CurrentBlockIdx - player.InBlockPosition) * TrekBlock.BlockWidth;
			pos.y = 0f;
			transform.localPosition = pos;
		}
	}
}
