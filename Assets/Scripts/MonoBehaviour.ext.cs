using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Hike
{
	public static class MonoBehaviourExtension
	{
		public static void ForEach<T> (this IEnumerable<T> source, Action<T> action)
		{
			foreach (T element in source)
			{
				action (element);
			}
		}

	}
}
