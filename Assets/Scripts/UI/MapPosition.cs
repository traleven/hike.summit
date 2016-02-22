using UnityEngine;
using System.Collections;

namespace Hike
{
	public class MapPosition : MonoBehaviour
	{
		public void SetPosition(CrossroadInfo info)
		{
			transform.localPosition = info.MarkerPosition;
		}
	}
}
