using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Methods : MonoBehaviour
{
    public static void UpgradeCheck<T>(List<T> list, int length) where T : new() {
        try
        {
            if (list.Count == 0) list = new T[length].ToList();
            while (list.Count < length) list.Add(new T());
        }
        catch
        {
            list = new T[length].ToList();
        }
    }
}
