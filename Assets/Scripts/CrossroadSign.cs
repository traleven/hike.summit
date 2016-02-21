using UnityEngine;
using System.Collections;

namespace Hike
{
	public class CrossroadSign : MonoBehaviour
	{
		[SerializeField] private Player player;

		protected void LateUpdate ()
		{
			Vector3 pos = transform.localPosition;
			pos.x = (player.CurrentTrek.Blocks.Length - player.CurrentBlockIdx - player.InBlockPosition) * TrekBlock.BlockWidth;
			pos.y = 0f;
			transform.localPosition = pos;
		}
	}
}