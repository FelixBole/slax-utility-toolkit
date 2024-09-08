using System.Collections.Generic;
using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// A collection of utility functions for generating random values.
    /// </summary>
    public static class RandomUtils
    {
        /// <summary>
        /// Returns a random float between the x and y values of a Vector2.
        /// </summary>
        public static float RandomRange(Vector2 range)
        {
            return Random.Range(range.x, range.y);
        }

        /// <summary>
        /// Returns a random color.
        /// </summary>
        public static Color RandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }

        /// <summary>
        /// Returns a random element from a weighted array of items.
        /// </summary>
        public static T GetRandomWeighted<T>(List<T> items, List<float> weights)
        {
            if (items.Count != weights.Count)
                throw new System.ArgumentException("Items and weights must have the same count.");

            float totalWeight = 0;
            foreach (float weight in weights)
                totalWeight += weight;

            float randomWeight = Random.Range(0, totalWeight);
            float currentWeight = 0;

            for (int i = 0; i < items.Count; i++)
            {
                currentWeight += weights[i];
                if (randomWeight <= currentWeight)
                    return items[i];
            }

            return default; // Fallback
        }
    }
}
