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

			Debug.Log(string.Format("Set up crossroad of {0} treks", crossroad.Length));
			dropdown.ClearOptions();
			dropdown.AddOptions(crossroad.Select(trek => trek.name).ToList());
			dropdown.RefreshShownValue();
		}

		public void ApplyTrek(Player player)
		{
			player.GoTo(crossroad[dropdown.value], player.TrekDirection);
		}
	}
}
