using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject
{
	public enum EItemType
	{
		Socks,
		FishingRod,
		Food,

	}

	public GameObject Shape;
	public float WeightKoeff;
	public float Weight = 5f;
	public int Amount = 1;
	public EItemType Type;
}
