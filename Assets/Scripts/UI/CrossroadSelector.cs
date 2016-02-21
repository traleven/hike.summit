using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

namespace Hike
{
	public class CrossroadSelector : MonoBehaviour
	{
		[SerializeField] private Dropdown dropdown = null;

		private TrekInfo[] crossroad;

		public void SetUp(TrekInfo[] crossroad)
		{
			this.crossroad = crossroad;

			dropdown.ClearOptions();
			dropdown.AddOptions(crossroad.Select(trek => trek.name).ToList());
			dropdown.value = 0;
			dropdown.RefreshShownValue();
		}

		public void ApplyTrek(Player player)
		{
			player.GoTo(crossroad[dropdown.value], player.TrekDirection);
		}
	}
}
