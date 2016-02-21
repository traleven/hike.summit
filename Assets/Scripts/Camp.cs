using UnityEngine;
using System.Collections;

namespace Hike
{
	public class Camp : MonoBehaviour
	{
		[SerializeField] private Player player;
		[SerializeField] private StatsManager stats;

		protected void Update ()
		{
			stats.TickCamping(Timer.GameDeltaTime, player);
		}
	}
}
