using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Methods : MonoBehaviour
{
    public static List<T> CreateList<T>(int capacity) => Enumerable.Repeat(default(T), capacity).ToList();

    public static void UpgradeCheck<T>(ref List<T> list, int length) where T : new() {
        try
        {
            if (list.Count == 0) list = CreateList<T>(length);
            while (list.Count < length) list.Add(new T());
        }
        catch
        {
            list = CreateList<T>(length);
        }
    }
}
