using UnityEngine;
using System.Collections;

namespace Hike
{
	[CreateAssetMenu]
	public class CrossroadInfo : ScriptableObject
	{
		public Sprite MapMarker;
		public Sprite TrekMarker;
		public Vector3 MarkerPosition;
	}
}
