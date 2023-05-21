using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    public static void ShuffleArray<T>(this System.Random rng, List<T> array)
    {
        int n = array.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
