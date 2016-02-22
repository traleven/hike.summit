using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

namespace Hike
{
	public class CrossroadSelector : MonoBehaviour
	{
		[SerializeField] private Dropdown dropdown = null;

		private TrekInfo.Crossroad[] crossroad;

		public void SetUp(TrekInfo.Crossroad[] crossroad)
		{
			this.crossroad = crossroad;

			dropdown.ClearOptions();
			dropdown.AddOptions(crossroad.Select(route => route.RouteName).ToList());
			dropdown.value = 0;
			dropdown.RefreshShownValue();
			//dropdown.template.GetComponent<CanvasRenderer>();
		}

		public void ApplyTrek(Player player)
		{
			player.GoTo(crossroad[dropdown.value].Trek, crossroad[dropdown.value].Direction);
		}
	}
}
